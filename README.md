# Library_DB
This project is an assignment for the Database course.
The idea is to create a database of my existing books that I have at home, to then be able to keep track of them via a graphical application.
To finish in time, the application will first only categorize the children's books I have at home. The database will be built using MYSQL and will maintain the standard of the third normalization form.

Personligt bibliotek.
Beskrivning av DB – inlämningsuppgift
Under denna uppgift har jag valt att göra ett personligt bibliotek där jag har en app som hjälper mig hålla koll på mina befintliga böcker som finns hemma. För att minska arbetets storlek så har jag valt att bara lägga in mitt barns böcker då de är en mindre mängd att hålla koll på.
Databasen som är kopplad till applikationen innehåller då bara barnböcker för tillfället, annars är den uppbyggd för att kunna innehålla andra sorters böcker. Databasen innehåller 6 tabeller, en av dessa är en linked-table. 

•	Books table
•	Authors table
•	Categorys table
•	Language table
•	Favorits table
•	Language_books table

Books tabell innehåller FKs till authors, category och favorites table, sedan är de en linked table mellan books och languages då vi har vissa böcker i mer än ett språk.

Applikationen innehåller ett fönster med 3 olika pages. Main window innehåller en tom plats för de olika sidorna. Den innehåller även en header som hjälper dig navigera till de olika pages som finns genom olika knappar.

Main page innehåller en sök låda, när den används slussas du vidare till listBooks page som sedan visar upp sökresultatet. Sökfunktionen tillåter sökning av författarnamn och boktitlar men inte mer än det förtillfället. 

ListBooks page innehåller en datagrid som visar upp befintliga böcker i databasen. Här har jag valt att korta ner informationen som visas i tabellen genom att solla de columner och tabeller som visas via en stored procedure vid namn ”SelectBooksWithAuthors”. Listbooks page ger dig även möjligheten att ta bort och uppdatera den bok du valt i listan. Tanken va även att när du valt en bok så skulle bild och titel visas längs upp på sidan, men valde att spara den funktionen till senare. Väljer man att uppdatera en bok så slussas man vidare till AddBooks page.
 
Addbooks page ger dig möjligheten att uppdatera boken du valt men även lägga till en ny bok i databasen. Här kan du välja att fylla i alla rutor eller låta dem vara blanka.

Här är 10 böcker du kan kopiera för att enklare göra en sökning: - finns självklart fler i db
1.	Vi leker utomhus, Georgie Birkett
2.	Mönster, Kathryn Smith
3.	Jag leker Bondgård, Bobbie Brooks
4.	Hönan och ägget, Hanna Albrektson
5.	Vi Hjälper!, Anett Berglin
6.	Imse vimse spindel, Catarina Kruvsval
7.	Barnets första ord, Elna Greig
8.	Titta Djur!, Elsa Beskows
9.	Lille Katt, Astrid Lindgren
10.	Min Dag, Hans Sande
