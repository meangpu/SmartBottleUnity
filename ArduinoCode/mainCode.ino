
#include <NewPing.h>
NewPing sonar (10, 11, 20);
const int delayTime = 100;
byte sonarDistance; // use byte because number is 0-20 byte = 0-255

void setup()
{
  Serial.begin(9600); //enable computer communication
  delay(50);
}

void loop()
{
  // Serial.println(sonar.ping_cm());  //print dis out
  
  getSonarValue();
  delay(delayTime);
}

void getSonarValue()
{
  byte nowDis = sonar.ping_cm();
  if (nowDis == sonarDistance)  // prevent sent duplicate data
  {
    return;
  }
  else
  {
    sonarDistance = nowDis;  // update value
    Serial.println(sonarDistance);  //print out  
  }
}
