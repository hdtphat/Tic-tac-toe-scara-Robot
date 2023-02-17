int en = 8 ;
int dirPInX = 5 ;
int stepPInX = 2 ;
int dirPInY = 6 ;
int stepPInY = 3 ;
int dirPInZ = 7 ;
int stepPInZ = 4 ;

int sizechess=0,positionchess=0;
int pulseMax = 0; //print to monitor
int pulseMin = 0; //print to monitor
String input="      ";
String siz=" ";
String pos="  ";
char dau;

void setup() {
  Serial.begin(9600);
  pinMode(en, OUTPUT); // Enable
  
  pinMode(stepPInX, OUTPUT); // StepX
  pinMode(dirPInX, OUTPUT);  // DirX
  
  pinMode(stepPInZ, OUTPUT); // StepY
  pinMode(dirPInZ, OUTPUT);  // DirY
  
  pinMode(stepPInY, OUTPUT); // StepZ
  pinMode(dirPInY, OUTPUT);  // DirZ

  digitalWrite(en,LOW);
 
  //digitalWrite(dirPInX, LOW); // Set Enable low
  //digitalWrite(dirPInZ, LOW);
}
void loop() {
  Serial.println("Please type in: Size_Positon_Character (EX: 3_4_X) ");
  while (Serial.available()==0);
  input=Serial.readString();
  siz[0]=input[0];
  pos[0]=input[2];
  pos[1]=input[3];
  dau=input[5];
  sizechess=siz.toInt();
  positionchess=pos.toInt();
  Serial.println(input);
  delay(500);
  if (dau=='X')
  {
    drawX(sizechess,positionchess);
  }
  if (dau=='O')
  {
    drawO(sizechess,positionchess);
  }
  delay(500);
}


/////////////////////////////////////////// STEPPER MOTORS OPERATION ///////////////////////////////////////////
void moveXY(long nStepX, int stepPInX,int dirX, long nStepY, int stepPInY,int dirY)
{
  double nStepMax = nStepX;
  double nStepMin = nStepY;
  int stepPInMax = stepPInX;
  int stepPInMin = stepPInY;

  double current_axis_min = 0;
  long steps_axis_min = 0;
  double ratio_max_min = 0;

  int pulseMax = 0; //print to monitor
  int pulseMin = 0; //print to monitor

  if (nStepY > nStepX)
  {
    nStepMax = nStepY;
    nStepMin = nStepX;
    stepPInMax = stepPInY;
    stepPInMin = stepPInX;
  }

  ratio_max_min = nStepMax / nStepMin;
  
  if( dirX==1) 
  {
    digitalWrite(dirPInX, HIGH); 
  }
  else
  {
    digitalWrite(dirPInX, LOW); 
  }

 if( dirY==1)
  {
    digitalWrite(dirPInY, HIGH); 
  }
  else
  {
    digitalWrite(dirPInY, LOW); 
  }

//      Serial.println("nStepMax");
//      Serial.println(nStepMax);
//      Serial.println("day la dpY" );
//      Serial.println(dpY);
     
  for (int i = 1 ; i <= nStepMax ; i = i + 1) {
    current_axis_min = i / ratio_max_min;

    if (current_axis_min - steps_axis_min >= 1) {
      digitalWrite(stepPInMin, HIGH);
      pulseMin = 1;
      steps_axis_min++;
    }

    digitalWrite(stepPInMax, HIGH);
    pulseMax = 1;
    delay(1);

    digitalWrite(stepPInMax, LOW);
    digitalWrite(stepPInMin, LOW);
    pulseMax = 0;
    pulseMin = 0;
    delay(1);
  }
}

/////////////////////////////////////////// END-EFFECTOR GOES FROM HOME TO START POSITION ///////////////////////////////////////////
void backhome(double t1,double t2)
{ 
  double dpX=0,dpY=0;
  int dirX=0,dirY=0;

//Inverse kinematics
  dpX=(abs(t1)*(180/PI))/(1.8/32);
  dpY=(abs(t2)*(180/PI))/(1.8/32);
  
//Analyze and adjust the direction of rotation
//Dir=1 clockwise and vice versa  
  if (t1<0)
  {dirX=1;}
  else
  {dirX=0;}

  if (t2<0)
  {dirY=1;}
  else
  {dirY=0;}

//Transmission ratio
  dpX=int(11.54*dpX);

  moveXYhome(dpX,stepPInX,dirX, dpY, stepPInY,dirY);
  delay(500);
}

/////////////////////////////////////////// DRAW O ///////////////////////////////////////////
void drawO(int siz,int pos)
{
  int hang = ceil(float(pos)/siz);
  int cot= pos%siz;
  if(cot==0)
  {
    cot=siz;
  }

//defining the cordinate X,Y of the center of the box to the bottom left edge of chessboard
  float tamX=cot*(30/float(siz))-(float(30/(2*siz)));
  float tamY=(siz+1-hang)*(30/float(siz))-30/(float(2*siz));
//Radius of letter O
  float R= 0.65*float(30/(2*siz));

//  Serial.print("X cordinate of the center of the box: ");
//  Serial.println(tamX);
//  Serial.print("Y cordinate of the center of the box: ");
//  Serial.println(tamY);
//  Serial.print("Radius R of circle: ");
//  Serial.println(R);

  int dirX=0,dirY=0;
  //L1 and L2 lenght
  float l1=24.094;
  float l2=18.0;
  double temp1=0,temp2=0,px=0,py=0,c1=0,s1=0,c2=0,s2=0;
  double t1=0,t2=0,dpX=0,dpY=0;
  
  for (double t = 0 ; t <= 2*PI + 0.1; t = t + 0.05)
  {   
    if (t==0.05)
    {   
      lenxuongZ(hang,0);
    }
    //circle equation  
    px=tamX + R*cos(t)-15;
    py=tamY + R*sin(t)+12;

    //Inverse kinematics
    c2=((px*px+py*py-l1*l1-l2*l2))/(2*l1*l2);
    s2=sqrt(abs(1-c2*c2));
    c1=px*(l1+l2*c2)+py*l2*s2;
    s1=py*(l1+l2*c2)-px*l2*s2;
    t1=atan(s1/c1);
    t2=atan(s2/c2);
    
    //
    if (c2<0)
    {t2=PI+t2;}
    if (c1<0)
    {t1=PI+t1;}

    //calculating the number of step (mode: micro step 1/32)
    dpX=(abs(t1-temp1)*(180/PI))/(1.8/32);
    dpY=(abs(t2-temp2)*(180/PI))/(1.8/32);
    
    //Analyze and adjust the direction of rotation
    //[(new theta)-(old theta)]>0  make dir=1 mean rotate clockwise 
    if ((t1-temp1)>0)
    {dirX=1;}
    else
    {dirX=0;}
    
    if ((t2-temp2)>0)
    {dirY=1;}
    else
    {dirY=0;}

    //Transmission ratio 
    dpX=int(11.54*dpX);

    if(t<=0.05)
      {moveXYhome(dpX,stepPInX,dirX, dpY, stepPInY,dirY);}
    else
      {moveXY(dpX,stepPInX,dirX, dpY, stepPInY,dirY);}
    
    //old theta
    temp1=t1;
    temp2=t2;
  }
  delay(500);
  lenxuongZ(hang,1);
  backhome(temp1,temp2);
}

/////////////////////////////////////////// DRAW A LINE ///////////////////////////////////////////
void drawline(float XA,float YA,float XB,float YB)
{
  int dirX=0,dirY=0;
  //L1 and L2 lenght
  float l1=24.094;
  float l2=18.0;
  double temp1=0,temp2=0,px=0,py=0,c1=0,s1=0,c2=0,s2=0;
  double t1=0,t2=0,dpX=0,dpY=0;
  
  //defining the cordinate X,Y of the center of the box to the origin (frame 0)   
  px=XA-15 ;
  py=YA+12 ;

  //Inverse kinematics
  c2=((px*px+py*py-l1*l1-l2*l2))/(2*l1*l2);
  s2=sqrt(abs(1-c2*c2));
  c1=px*(l1+l2*c2)+py*l2*s2;
  s1=py*(l1+l2*c2)-px*l2*s2;
  t1=atan(s1/c1);
  t2=atan(s2/c2);

  if (c2<0)
   {t2=PI+t2;}
  if (c1<0)
   {t1=PI+t1;}
  
  //old theta
  temp1=t1;
  temp2=t2;
  
  for (double t = 0 ; t <= 1 ; t = t + 0.1)
  {   
    //defining the cordinate X,Y of the center of the box to the origin (frame 0)   
    px=XA + (XB-XA)*t-15;
    py=YA + (YB-YA)*t+12;

    //Inverse kinematics
    c2=((px*px+py*py-l1*l1-l2*l2))/(2*l1*l2);
    s2=sqrt(abs(1-c2*c2));
    c1=px*(l1+l2*c2)+py*l2*s2;
    s1=py*(l1+l2*c2)-px*l2*s2;
    t1=atan(s1/c1);
    t2=atan(s2/c2);
    
    if (c2<0)
      {t2=PI+t2;}
    if (c1<0)
      {t1=PI+t1;}

    //Calculating number of step
    dpX=(abs(t1-temp1)*(180/PI))/(1.8/32);
    dpY=(abs(t2-temp2)*(180/PI))/(1.8/32);


    if ((t1-temp1)>0)
      {dirX=1;}
    else
      {dirX=0;}
    if ((t2-temp2)>0)
      {dirY=1;}
    else
      {dirY=0;}

    //Transmission ratio  
    dpX=int(11.54*dpX);

    moveXY(dpX,stepPInX,dirX, dpY, stepPInY,dirY);

    //old theta
    temp1=t1;
    temp2=t2;
  }  
  delay(500);     
}

/////////////////////////////////////////// DRAW X ///////////////////////////////////////////
void drawX(int siz,int pos)
{
  //Find the numerical order of collum and row of the box that is gonna be drawn down letter X
  int hang = ceil(float(pos)/siz);
  int cot= pos%siz;
  if(cot==0)
    {cot=siz;}

  //Calculate X,Y coordinate of the ccenter of the box to the bottom left of the chessboard
  float tamX=cot*(30/float(siz))-(float(30/(2*siz)));
  float tamY=(siz+1-hang)*(30/float(siz))-30/(float(2*siz));
  
  float d= 0.6*float(30/(2*siz));
  //Calculate X,Y coordinate of point A (upper left to the center of the box)
  float XA=tamX-d;
  float YA=tamY+d;

  //Calculate X,Y coordinate of point B (bottom right to the center of the box)
  float XB=tamX+d;
  float YB=tamY-d;

  //Calculate X,Y coordinate of point C (upper right to the center of the box)
  float XC=tamX+d;
  float YC=tamY+d;

  //Calculate X,Y coordinate of point D (bottom left to the center of the box)
  float XD=tamX-d;
  float YD=tamY-d;

  int dirX=0,dirY=0;
  //L1 and L2 lenght  
  float l1=24.094;
  float l2=18.0;
  double temp1=0,temp2=0,px=0,py=0,c1=0,s1=0,c2=0,s2=0;
  double t1=0,t2=0,dpX=0,dpY=0;
  
  for (double t = 0 ; t <= 1 ; t = t + 0.1)
  {   
    if (t==0.1)
      {   
        lenxuongZ(hang,0);
      }
    
    //line equation
    px=XA + (XB-XA)*t-15;
    py=YA + (YB-YA)*t+12;

    //Inverse kinematics
    c2=((px*px+py*py-l1*l1-l2*l2))/(2*l1*l2);
    s2=sqrt(abs(1-c2*c2));
    c1=px*(l1+l2*c2)+py*l2*s2;
    s1=py*(l1+l2*c2)-px*l2*s2;
    t1=atan(s1/c1);
    t2=atan(s2/c2);
    
    if (c2<0)
      {t2=PI+t2;}
    if (c1<0)
      {t1=PI+t1;}

    //calculate number of step
    dpX=(abs(t1-temp1)*(180/PI))/(1.8/32);
    dpY=(abs(t2-temp2)*(180/PI))/(1.8/32);

    //Analyze and adjust the direction of rotation
    //[(new theta)-(old theta)]>0  make dir=1 mean rotate clockwise   
    if ((t1-temp1)>0)
      {dirX=1;}
    else
      {dirX=0;}
      
    if ((t2-temp2)>0)
      {dirY=1;}
    else
      {dirY=0;}

    //Transmission rotation
    dpX=int(11.54*dpX);
    if(t<=0.1)
      {
        moveXYhome(dpX,stepPInX,dirX, dpY, stepPInY,dirY);
      }
    else
      {
        moveXY(dpX,stepPInX,dirX, dpY, stepPInY,dirY);
      }

    //old theta
    temp1=t1;
    temp2=t2;
  }
  delay(500); 
  lenxuongZ(hang,1);
  drawline(XB,YB,XC,YC); //B to C
  lenxuongZ(hang,0);
  drawline(XC,YC,XD,YD); //C to D
  digitalWrite(dirPInZ, LOW); 
  lenxuongZ(hang,1);
  
  //defining the cordinate X,Y of the center of the box to the origin (frame 0)      
  px=XD-15 ;
  py=YD+12 ;
  
  //Inverse kinematics
  c2=((px*px+py*py-l1*l1-l2*l2))/(2*l1*l2);
  s2=sqrt(abs(1-c2*c2));
  c1=px*(l1+l2*c2)+py*l2*s2;
  s1=py*(l1+l2*c2)-px*l2*s2;
  t1=atan(s1/c1);
  t2=atan(s2/c2);

  if (c2<0)
  {
    t2=PI+t2;
  }
  if (c1<0)
  {
    t1=PI+t1;
  }

  //old theta
  temp1=t1;
  temp2=t2;
    
  backhome(temp1,temp2);
}

/////////////////////////////////////////// END-EFFECTOR GOES FROM POINT TO POINT ///////////////////////////////////////////
void moveXYhome(long nStepX, int stepPInX,int dirX, long nStepY, int stepPInY,int dirY)
{
  double nStepMax = nStepX;
  double nStepMin = nStepY;
  int stepPInMax = stepPInX;
  int stepPInMin = stepPInY;
  double current_axis_min = 0;
  long steps_axis_min = 0;
  double ratio_max_min = 0;
  int pulseMax = 0; //print to monitor
  int pulseMin = 0; //print to monitor

  if (nStepY > nStepX) 
  {
    nStepMax = nStepY;
    nStepMin = nStepX;
    stepPInMax = stepPInY;
    stepPInMin = stepPInX;
  }

  ratio_max_min = nStepMax / nStepMin;
  if( dirX==1)
  {
    digitalWrite(dirPInX, HIGH); 
  }
  else
  {
    digitalWrite(dirPInX, LOW); 
  }

 if( dirY==1)
  {
    digitalWrite(dirPInY, HIGH); 
  }
  else
  {
    digitalWrite(dirPInY, LOW); 
  }

//      Serial.println("nStepMax");
//      Serial.println(nStepMax);
//      Serial.println("day la dpY" );
//      Serial.println(dpY);
     
  for (int i = 1 ; i <= nStepMax ; i = i + 1) {
    current_axis_min = i / ratio_max_min;

    if (current_axis_min - steps_axis_min >= 1) {
      digitalWrite(stepPInMin, HIGH);
      pulseMin = 1;
      steps_axis_min++;
    }

    digitalWrite(stepPInMax, HIGH);
    pulseMax = 1;
    delay(0.1);

    digitalWrite(stepPInMax, LOW);
    digitalWrite(stepPInMin, LOW);
    pulseMax = 0;
    pulseMin = 0;
    delay(1);
  }
}

/////////////////////////////////////////// STEPPER Z GOES UP AND DOWN ///////////////////////////////////////////

// chieu=0 z goes down
void lenxuongZ(int vitrihang,int chieu)
  {
    //our chessboard sinks to one side so we seperated into 3 sistuations so that the pen can touch the chessboard
    int soxung;
    if (vitrihang==1)
      {
        soxung=6000;
      }
    
    if (vitrihang==2)
      {
        soxung=6000;
      }
    if (vitrihang==3)
      {
        soxung=6000;
      }
    
    //Z goes downward
    if(chieu==0)
    {
      digitalWrite(dirPInZ, HIGH); 
      for (int i=1;i<=soxung;i++)
        {
          digitalWrite(stepPInZ,HIGH);
          delay(0.1);
          digitalWrite(stepPInZ,LOW);
          delay(1);
        }        
    }

    //z goes upward
    else
    {
        digitalWrite(dirPInZ, LOW);
        for (int i=1;i<=soxung;i++)
        {
          digitalWrite(stepPInZ,HIGH);
          delay(0.1);
          digitalWrite(stepPInZ,LOW);
          delay(1);
        } 
    }
     
}
