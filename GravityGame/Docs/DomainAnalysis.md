#Domain Analysis

## Project glossary

<a id="REQ_01"></a>

![Alt text](http://g.gravizo.com/g?
  @startuml;
  Planet ^-- InhabitedPlanet;
  class EvilObject;
  class Predictor;
  class Player;
  class Trace;
  Predictor ^-- Trace;
  @enduml;
)