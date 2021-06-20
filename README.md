# Užitečný software
## Aplikace Počasí
## Specifikace požadavků

Martin Goffa <br/>
goffa.martin@skola.ssps.cz <br/>
15. 5. 2021

Verze 1.0

* Úvod
  * Účel dokumentu
    * Účelem tohoto dokumentu je vytvoření WPF aplikace, která bude zobrazovat online data o počasí
  * Kontakty
    * Martin Goffa goffa.martin@skola.ssps.cz, tel. 666 666 666
  * Odkazy na ostatní dokumenty
    * https://openweathermap.org/api
* Celkový popis
  * Funkce
    * Aplikace bude volat API, ze kterého bude zobrazovat data o počasí
    * Data by měla uživateli dát stručný přehled o tom, jaké je počasí v ním určené lokaci
  * Uživatelské skupiny
    * běžný PC uživatel
  * Omezení návrhu a implementace   
    * Volání API pouze v případě potřeby obnovení dat
    * Předpověď nebude součástí softwaru, pouze aktuální data o počasí
* Požadavky na rozhraní
  * Uživatelská rozhraní 
    * Windows Presentation Foundation
  * Softwarová rozhraní 
    * Windows
* Vlastnosti systému
  1. Výběr lokace
    * Vstup: uživatel napíše jméno lokace do TextBoxu
    * Akce: zjištění zda se danná lokace vyskytuje v databázi pomocí databindingu na vstupu
    * Výstup: zobrazení informací o počasí (den, datum, teplota, počasí, vlhkost, síla větru, oblačnost, tlak, hodinová předpověd, týdenní předpověd)
  2. Vypsání nových dat
    * Vstup: uživatel může refreshnout data pomocí tlačítka
    * Akce: volání API na základě výběru
    * Výstup: zobrazení požadovaných informací o počasí pomocí labelů v přehledném rozložení
  3. Refresh
    * Vstup: kliknutí na tlačítko refresh
    * Akce: zavolání API a spracování dat
    * Výstup: Aktualizovaná data se zobrazí v uživatelském rozhraní  
* Nefunkční požadavky
    * Odezva
      * Systém úspěšně vyhledá a vypíše požadovaná data do 4 sekund
    * Spolehlivost
      * 99% šance že systém úspěšně vyhledá a vypíše požadovaná data 
    * Bezpečnost
      * Systém nepracuje s žádnými osobními daty

## Funkční specifikace

Verze 1.0

* Úvod
  * Účel dokumentu
    * Účelem tohoto dokumentu je vytvoření WPF aplikace, která bude zobrazovat online data o počasí
  * Kontakty
    * Martin Goffa goffa.martin@skola.ssps.cz, tel. 666 666 666
  * Odkazy na ostatní dokumenty
    * https://openweathermap.org/api
* Scénáře
  * Způsoby použití
    * Uživatel má možnost najít aktuální data o počasí v určité oblasti, kterou zvolí, pakliže se nachází v databázi.
    * Těmito daty je myšleno: denní, hodinová předpověd, aktuální teplota, síla větru  
  * Personas
    * Každý uživatel má stejná práva v aplikaci, nijak se nepřihlašují, nijak se neliší 
  * Vymezení rozsahu
    * Program při ukončení nebude ukládat data o posledním hledání
    * Uživatel při spuštění musí znovu zadat jméno lokace 
* Celková hrubá architektura
  * Pracovní tok
    * Uživatel spustí aplikaci
    * zadá jméno lokace
    * vypíšou se mu aktuální data o počasí k dané lokaci
    * možnost výběru typu předpovědi
  * Detaily
    * Aplikace bude jedno okno WPF
    * Černé pozadí
    * Bílý text a ikony
    * Při prvním spuštění je lokace defaultně nastavena na Praha
    * Vypsání pomocí labelů a obrázků vyhovující danému počasí
      * TextBox uprostřed nahoře: Název lokace (možnost zadání nové lokace)
      * Label vlevo nahoře: Velkým písmem Aktuální teplota ve °C
      * Obrázek vpravo nahoře: Obrázek symbolizující aktuální počasí (slunečno, zataženo, déšť....)
      * Labely dole pod teplotou budou obsahovat informace o pocitové teplotě, min a max teplotě, vlhkosti, síle větru, oblačnosti a tlaku
    * Hodinová předpověď (pro mobilní aplikaci)
      * Řádek rozdělen do sloupců
      * Každý sloupec symbolizuje jednu hodinu
      * V bloku je informace kolik bude stupňů a obrázek symbolizující počasí 
      * S bloky lze pohybovat do stran pomocí scrollbaru
    * Týdenní předpověď (pro mobilní aplikaci)
      * Sloupec rozdělený do řádků
      * Každý řádek symbolizuje jeden den
      * V bloku je informace kolik bude stupňů a obrázek symbolizující počasí 
      * S bloky lze pohybovat nahoru a dolů pomocí scrollbaru
    * Refresh pomocí Enter v TextBoxu
    * v případě špatného zadání lokace - Error message pomocí messageboxu
  * Všechny dohodnuté principy 
    * Data vypisována na základě API 

* Design prototype pro WPF software
![desing_prototype](https://github.com/goffamartin/Weather/blob/main/design_prototype.png "design_prototype")
