# BlueCore-Tech-Servo-Control-C-Application
c# Application to control a robotic arm with arduino

Below is the arduino code

/*
Author: Danny van den Brande, BlueCore Tech. Arduinosensors.nl
This code below belongs the the C# Windows application i created.
Servo control for arduino, you can set-up your automatic programs in the source code
of the c# application, the buttons are allready pre-set with the commands that the arduino 
needs to receive. There is one example Automated program in the arduino code, 
you can copy this and add more automated programs, more instructions are in the code itself.

The C# app is open source and avaialble in the instructable or our blog
If you cannot find the source code feel free to contact us on 
contact@arduinosensors.nl
 */

#include <Servo.h>  
Servo myservoA;  
Servo myservoB;
Servo myservoC;
Servo myservoD;
Servo myservoE;
Servo myservoF;
Servo myservoG;
int i,pos,myspeed,myshow;
int sea1,seb2,sec3,sed4,see5,sef6,seg7;
static int v=0;
boolean isConnected = false;
String mycommand="";  /// Serial capture   #auto: automatic operation  #com: computer serial port control  #stop: standstill
static int mycomflag=1; // #auto：2 automatic operation  , #com： 1  computer serial port control    #stop：0  standstill 


void myservosetup()  //Standstill state for robot arm if mycomflag=0
{
   sea1=myservoA.read();
   seb2=myservoB.read();
   sec3=myservoC.read();
   sed4=myservoD.read();
   see5=myservoE.read();
   sef6=myservoF.read();
   seg7=myservoG.read();
   
   myspeed=500;
   for(pos=0;pos<=myspeed;pos+=1)
   {
    myservoA.write(int(map(pos,1,myspeed,sea1,66)));
    myservoB.write(int(map(pos,1,myspeed,seb2,90)));
    myservoC.write(int(map(pos,1,myspeed,sec3,50)));
    myservoD.write(int(map(pos,1,myspeed,sed4,90)));
    myservoE.write(int(map(pos,1,myspeed,see5,120)));
    myservoF.write(int(map(pos,1,myspeed,sef6,90)));  
    myservoG.write(int(map(pos,1,myspeed,seg7,90)));   
    delay(1);
   }
}

void setup() 
{ 
  pinMode(13,INPUT);
  pinMode(12,INPUT);  
  Serial.begin(9600);
  myshow=0;
  mycomflag=1; // the  ARM default  state: 2 automatic operation
  myservoA.attach(3);    
  myservoB.attach(5);     
  myservoC.attach(6);  
  myservoD.attach(9);  
  myservoE.attach(10); 
  myservoF.attach(11);
  myservoG.attach(8);
  
  myservoA.write(66);
  myservoB.write(90);
  myservoC.write(50);
  myservoD.write(90);
  myservoE.write(120);
  myservoF.write(90);    
  myservoG.write(120);  
}

void loop() 
{ 
  while (Serial.available() > 0)  
    {
        mycommand += char(Serial.read());
        delay(2);
    }
    if (mycommand.length() > 0)
    {
        if(mycommand=="#auto")
        {
          mycomflag=2;
         // Serial.println("automatic program");
          mycommand="";
        }
//        if(mycommand=="#auto2")//uncomment this part and add more if your adding more automatic programs
//        {                      //with mycomflag=3;, mycomflag=4; etc...
//          mycomflag=3;         //the #auto2 command is already set in the c# program at button5
//          Serial.println("automatic program2");
//          mycommand="";
//        }
        if(mycommand=="#com")
        {
          mycomflag=1;
        //  Serial.println("computer control station");
          mycommand="";
          myservosetup();
        }
        if(mycommand=="#stop")
        {
          mycomflag=0;
        //  Serial.println("stop station");
          mycommand="";
        }
        
    }
 /////////////////// 
  
  if(mycomflag==1)  // this is used for the control panel on pc (COM port control)
  {      
 
   for(int m=0;m<mycommand.length();m++) 
  {
    char ch = mycommand[m];   
    switch(ch)
    {
      case '0'...'9':
      v = v*10 + ch - '0';   
      break;
      
      
      
      case 'a':  
      if(v >= 5 || v <= 175 ) myservoA.write(v); 
      v = 0;
      break;

      case 'b':   

      myservoB.write(v);  
      v = 0;
      break;
      case 'c':   
      if(v >= 20 ) myservoC.write(v);   
      v = 0;
      break;
      case 'd':  
      myservoD.write(v);   
      v = 0;
      break;
      case 'e':  
      myservoE.write(v);   
      v = 0;
      break;
      case 'f':  
      myservoF.write(v);   
      v = 0;
      break;
      case 'g':  
      myservoG.write(v);   
      v = 0;
      break;
    }
   
    }  
   mycommand="";
  }  

  // setup your automatic program 1 here below, you can add more youself
  // and assign them to buttons 2 3 and 4 in the c# program
  // make sure to add the following part of code below to at the top of void loop when 
  // you add new automatic programs for the c# buttons, make sure to change it to mycomflag=3 etc.
  // the c# code is already pre coded for you to add new programs.
  // the command for button 1 is #auto, for button2 2 is #auto2, button 3 is #auto3 and button 4 #auto4
  // stop is #stop, and to use slider control the button "com control" sends #com
//  if(mycommand=="#auto2")
//        {
//          mycomflag=2;
//          Serial.println("auto station");
//          mycommand="";
//        }
///////////////////////////////////////////////////////////////////////////////////
  if(mycomflag==2)
  {    
   delay(3000);
   myservosetup();
   myspeed=500;
    for(pos = 0; pos <=myspeed; pos += 1)  
  {                                
    myservoA.write(int(map(pos,1,myspeed,66,90))); 
    myservoB.write(int(map(pos,1,myspeed,90,40))); 
    delay(1);                       
  }
   delay(1000);
   myspeed=500;
  for(pos = 0; pos <=myspeed; pos += 1)  
  {                                
    myservoA.write(int(map(pos,1,myspeed,50,65))); 
    myservoB.write(int(map(pos,1,myspeed,90,170))); 
    myservoC.write(int(map(pos,1,myspeed,90,5))); 
    delay(1);                       
   }
  myspeed=1000;
  for(pos = 0; pos <=myspeed; pos += 1)  
  {                                
    myservoB.write(int(map(pos,1,myspeed,40,70))); 
    myservoC.write(int(map(pos,1,myspeed,65,50))); 
    delay(1);                       
   }
   myspeed=500;
  for(pos = 0; pos <=myspeed; pos += 1)  
  {                                
    myservoC.write(int(map(pos,1,myspeed,50,45))); 
    myservoA.write(int(map(pos,1,myspeed,170,90))); 
    myservoB.write(int(map(pos,1,myspeed,5,27)));
    myservoA.write(int(map(pos,1,myspeed,90,40)));
    delay(1);                       
   }
   myspeed=1000;
  for(pos = 0; pos <=myspeed; pos += 1)  
  {                                
    myservoA.write(int(map(pos,1,myspeed,90,140))); 
    myservoC.write(int(map(pos,1,myspeed,40,130)));    
    delay(1);                       
   }  
    myspeed=500;
    for(pos = 0; pos <=myspeed; pos += 1)  
  {                                
    myservoA.write(int(map(pos,1,myspeed,140,90))); 
    myservoC.write(int(map(pos,1,myspeed,45,50))); 
    myservoB.write(int(map(pos,1,myspeed,70,50)));  
    delay(1);                       
  } 
  }
  
  if(mycomflag==0) // this is used when the robot is idle when pressed on "Stop robot" in the C# Application
  {
   myservosetup();
  }
}
