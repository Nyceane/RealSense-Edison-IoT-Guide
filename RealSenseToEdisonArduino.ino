const int ledPin = 2;     // the number of the pushbutton pin
void setup() {
  // initialize the LED pin as an output:
  pinMode(ledPin, OUTPUT);
  Serial.begin(9600);
}

void loop() {
  if (Serial.available()>0) 
  /* read the most recent byte */
  {
    int tmp = Serial.parseInt();
    if(tmp == 0)
    {
      // turn LED off:
      digitalWrite(ledPin, LOW);
    }
    else if (tmp == 1)
    {
        // turn LED on:
        digitalWrite(ledPin, HIGH);
    }
  }
}

