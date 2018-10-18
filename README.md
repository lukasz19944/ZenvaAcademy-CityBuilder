# ZenvaAcademy-CityBuilder
Prosta gra turowa typu 'city builder' zrobiona w Unity z kursu Zenva Academy

![Gra](/Screenshots/game.png?raw=true)

## Informacje
- Gracz może postawić trzy typu budynków: dom (zwiększa populację), farma (zwiększa produkcję jedzenia) i fabrykę (zwiększa miejsca pracy) oraz drogę
- Aby postawić budynek należy wybrać go z menu budowy i kliknąć PPM na określone miejsce na mapie, aby usunąć budynek nalezy na niego kliknąć
- Ponadto możliwość stawiania wielu budynków na raz trzymając lewy shift
- Możliwość nawigacji kamerą: przybliżanie i oddalanie (Scroll) oraz przesuwanie (ŚPM)
- Aktualizacja danych po każdej turze
- Przy każdej turze obliczane są:
-- Praca:
--- Wolne miejsca = liczba fabryk * 10
--- Osoby pracujące = MIN(populacja, wolne miejsca)
-- Pieniądze:
--- Pieniądze += osoby pracujące * 2
-- Jedzenie:
--- Jedzenie += liczba farm * 4
--- Jedzenie -= populacja * 0.25 (jeden człowieka zjada 0.25 jedzenia)
-- Populacja:
--- Limit populacji = liczba domów * 5
--- Jeśli jest wystarczająco jedzenia to populacja rośnie 
--- Jeśli brakuje jedzenia to populacja spada


## Do zrobienia
- Zablokowanie możliwości stawiania budynków na krawędziach mapy
- Aktualizacja parametrów miasta w przypadku usuwania budynków (np. obecnie po usunięciu domu populacja nie zmienia się, a powinna zmaleć o 5)
- Dodanie menu
- Dodanie poziomu trudności
- Dodanie dźwięku
- Dodanie nawigacji kamerą przy pomocy WASD
- Dodanie możliwości wyboru wielkości mapy
- Anulowanie wybrania budynku (odkliknięcie w menu budowy)


## Źródło
https://academy.zenva.com/product/create-a-city-building-game-with-unity/
