int i = 0;
int sensorPin = A6;  
int lightPin = A3;
int tempPin = A0; 

void setup() {
  //Initialize serial and wait for port to open:
  Serial.begin(9600);
  while (!Serial) {
    ; // wait for serial port to connect. Needed for native USB port only
  }
  Serial.println("octopusengine - UART test - start()");
}

void loop() {
   int sensorValue1 = analogRead(sensorPin);
   delay(10);
   int sensorValue2 = analogRead(sensorPin);
   delay(10);
   int value = (sensorValue1+sensorValue2)/2;
  
  String toSend = String(value);
  Serial.print("U");
  Serial.println(toSend);

   sensorValue1 = analogRead(lightPin);
   delay(10);
   sensorValue2 = analogRead(lightPin);
   delay(10);
   value = (sensorValue1+sensorValue2)/2;
  
  toSend = String(value);
  Serial.print("L");
  Serial.println(toSend);

 sensorValue1 = analogRead(tempPin);
   delay(10);
   sensorValue2 = analogRead(tempPin);
   delay(10);
   value = (sensorValue1+sensorValue2)/2;
  
  toSend = String(value);
  Serial.print("T");
  Serial.println(toSend);

  
  //Serial.print(",");
  
  i++;
  if (i>1000) i= 0;
  delay(100);
}
