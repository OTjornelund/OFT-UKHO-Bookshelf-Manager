import { Component } from '@angular/core';
import { Hero } from '../hero';
//import { HEROES } from '../mock-heroes'; // <-- No longer needed
import { HeroService } from '../hero.service';

@Component ({
    selector: 'app-heroes',
    templateUrl: './heroes.component.html',
    styleUrls: ['./heroes.component.css']
  })
export class HeroesComponent {

  heroes: Hero[] = []; //Previously: heroes = HEROES;

  selectedHero?: Hero;

  //Parameter below both defines private property and identifies it as "HeroService" injection site.
  constructor(private heroService: HeroService) { }

  ngOnInit(): void {
    this.getHeroes(); //Angular calls ngOnInit() by itself, after the constructor
  }

  getHeroes(): void {
    this.heroes = this.heroService.getHeroes(); //Retrieves heroes from the Service
    //(This consumes the getHeroes() result as if HeroService can fetch heroes _synchronously_.)
  }

  onSelect(hero: Hero): void {
    this.selectedHero = hero;
  }
}
