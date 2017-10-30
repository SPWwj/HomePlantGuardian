#include <LiquidCrystal.h>
#include <Servo.h>

Servo myservo;  // create servo object to control a servo
int pos = 90;    // variable to store the servo position

String inputString = "";         // a string to hold incoming data
boolean stringComplete = false;  // whether the string is complete
String commandString = "";

int led2Pin = 9;


boolean isConnected = false;
boolean LedState = false;

const int rs = 12, en = 11, d4 = 5, d5 = 4, d6 = 3, d7 = 2;
LiquidCrystal lcd(rs, en, d4, d5, d6, d7);


void setup() {
  Serial.begin(9600);
  myservo.attach(8);  // attaches the servo on pin 9 to the servo object
  pinMode(led2Pin,OUTPUT);
  initDisplay();
  myservo.write(pos+5);
}

void loop() {

      if(LedState == true)
    {
      if (pos>5)
      {
        pos-=1;
        myservo.write(pos);
        delay(25);   
       }
    }
    else
    { 
      if (pos<85)
      {
        pos+=1;
        myservo.write(pos);
        delay(25);   
       }
    }   

if(stringComplete)
{
  stringComplete = false;
  getCommand();
  
  if(commandString.equals("STAR"))
  {
    lcd.clear();
  }
  if(commandString.equals("STOP"))
  {
    turnLedOff(led2Pin);
    lcd.clear();
    lcd.print("Ready to connect");    
  }
  else if(commandString.equals("TEXT"))
  {
    String text = getTextToPrint();
    printText(text);
  }
  else if(commandString.equals("LED1"))
  {
    LedState = getLedState();
  }
    else if(commandString.equals("LED2"))
  {
    LedState = getLedState();
    if(LedState == true)
    {
      turnLedOn(led2Pin);
    }
    else
    {
      turnLedOff(led2Pin);
    }   
  }
  
  inputString = "";
}

}

void initDisplay()
{
  lcd.begin(16, 2);
  lcd.print("Ready to connect");
}

boolean getLedState()
{
  boolean state = false;
  if(inputString.substring(5,7).equals("ON"))
  {
    state = true;
  }else
  {
    state = false;
  }
  return state;
}

void getCommand()
{
  if(inputString.length()>0)
  {
     commandString = inputString.substring(1,5);
  }
}

void turnLedOn(int pin)
{
  digitalWrite(pin,HIGH);
}

void turnLedOff(int pin)
{
  digitalWrite(pin,LOW);
}


String getTextToPrint()
{
  String value = inputString.substring(5,inputString.length()-2);
  return value;
}

void printText(String text)
{
  lcd.clear();
  lcd.setCursor(0,0);
    if(text.length()<16)
    {
      lcd.print(text);
    }else
    {
      lcd.print(text.substring(0,16));
      lcd.setCursor(0,1);
      lcd.print(text.substring(16,32));
    }
}

void serialEvent() {
  while (Serial.available()) {
    // get the new byte:
    char inChar = (char)Serial.read();
    // add it to the inputString:
    inputString += inChar;
    // if the incoming character is a newline, set a flag
    // so the main loop can do something about it:
    if (inChar == '\n') {
      stringComplete = true;
    }
  }
}

