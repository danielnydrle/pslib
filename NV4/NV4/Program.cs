using NV4.Models;

Vysilac vysilacCT = Vysilac.Instance("CT");
Vysilac vysilacNova = Vysilac.Instance("Nova");

Prijimac prijimac1 = new Prijimac();
Prijimac prijimac2 = new Prijimac();

vysilacCT.PosliZpravu("ZPRAVY", "Udalosti");
vysilacCT.PosliZpravu("ZPRAVY", "Udalosti Komentare");

prijimac1.PrihlasSeKOdberu("CT", "ZPRAVY");
prijimac1.PrehrajZpravu();
prijimac2.PrehrajZpravu();

prijimac1.PrihlasSeKOdberu("CT", "SPORT"); // zatím na ČT neprobíhá vysílání na kanále SPORT
prijimac1.PrehrajZpravu(); // tudíž není vysílání k dispozici

prijimac1.PrihlasSeKOdberu("Nova", "ZABAVA"); // zatím na Nově neprobíhá vysílání na kanále ZABAVA
prijimac1.PrehrajZpravu(); // tudíž není vysílání k dispozici

vysilacNova.PosliZpravu("ZABAVA", "Ulice");
prijimac1.PrehrajZpravu();

vysilacNova.ZastavVysilani("ZABAVA"); // na Nově se přestalo vysílat na kanále ZABAVA
prijimac1.PrehrajZpravu(); // tudíž není vysílání k dispozici

prijimac1.OdeberSeZOdberu("Nova", "ZABAVA"); // přijímač se odebral z odběru kanálu ZABAVA vysílače Nova
vysilacNova.PosliZpravu("ZABAVA", "Vymena manzelek"); // na Nově se začalo vysílat na kanále ZABAVA
prijimac1.PrehrajZpravu(); // vysílání není k dispozici, protože přijímač není přihlášen k odběru