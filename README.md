# GenericList-Template
### GenericList - Probleme bzw wie wurde es gemacht
Implementing bubble Sort Algo in C# using generic Methods
Die fehlersuche war sehr zeitaufwändig weil ich versehentlich in der Nodeklasse  
`       public  Node(T dataObject)
        {
            **T** DataObject = dataObject;
        }
`
das geschrieben habe. 
Problem war hauptsächlich die Insert Methode welche ich durch die Methode MyInsert ersetzen musste. Bubblesort wurde von mir implementiert
durch die verwendung des Indexers (  `public T this[int index]` ) ähnlich einem Bubblesort-Algorithmus wo man Arrays implementiert bzw. durch die verwendung des IComareable Interfaces;  

### Generics 
Vorteile von Generics ist die Typsicherheit bzw. gegenüber von Objects auch das die Größe des Datentyps in der Regel geringer ist bzw.
sich dadurch auch die Laufzeit verbessert.

### Vor- und Nachteile von Sourcecode Management-Systemen
#### Vorteile: Es können verschiedene Branches angelegt werden, daher sind mehrere Entwicklungsstände generierbar bzw.
wieder leicht wiederherstellbar. Leichtes zusammenarbeiten mit verschiedenen Entwicklern an verschieden Orten.
#### Nachteil: Es könnne Merge Konflikte auftreten;
Teilweise schwierig zu lernen wenn der Umgang damit nicht geübt bzw. die IDE relativ unbekannt ist. 
