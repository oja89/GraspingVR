
char myCol[20];
int thumb = 12;
int indexfin = 11;
int middle = 10;
boolean newData = false;
const byte charAmount = 32;
char receivedData[charAmount];
int voltages[3];

void setup() {
  pinMode(thumb, OUTPUT);
  pinMode(indexfin, OUTPUT);
  pinMode(middle, OUTPUT); 
  Serial.begin(9600);
}

void loop() {
  receiveMessage();
}

void receiveMessage() {
  static boolean receiving = false;
  static byte counter = 0;
  char startMarker = '<';
  char endMarker = '>';
  char receivedChar;
  newData = false;
  while(Serial.available() > 0 && newData == false) {
    receivedChar = Serial.read();
    if(receiving == true){
      //Check if final char received
      if(receivedChar != endMarker){
        receivedData[counter] = receivedChar;
        counter++;
        if(counter >= charAmount){
          counter = charAmount - 1;
        }
      }
      else {
        receivedData[counter] = '\0'; //end of message
        receiving = false;
        counter = 0;
        //newData = true;
        parseMessage();
        break;
      }
    }
    else if(receivedChar == startMarker){
      receiving = true;
      receivedChar = '\0';
    }
  } 
}

void parseMessage(){
    char *token;
    const char delim[2] = ",";    
    int i=0;
    
    Serial.println(receivedData); // Printing received data in Unity log
    
    token = strtok(receivedData, delim);
    while(token != NULL){
        voltages[i] = atoi(token);
        token = strtok(NULL, delim);
        i++;
    }
    setVoltage(voltages[0], voltages[1], voltages[2]);
}
 
/*
 * Vibrate motors. 
 * (max value for each finger should be 90 for avoiding to break components)
 */
void setVoltage(int t_voltage, int i_voltage, int m_voltage){
      analogWrite(middle, m_voltage);
      analogWrite(indexfin, i_voltage);
      analogWrite(thumb, t_voltage);
}
