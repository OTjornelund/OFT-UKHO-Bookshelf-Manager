import { Component } from '@angular/core';
import { Hero } from '../hero';
import { HeroService } from '../hero.service';

@Component ({
    selector: 'app-heroes',
    templateUrl: './heroes.component.html',
    styleUrls: ['./heroes.component.css']
  })
export class HeroesComponent {

  heroes: Hero[] = [];

  selectedHero?: Hero;

  //Parameter below both defines private property and identifies it as "HeroService" injection site.
  constructor(private heroService: HeroService) { }

  ngOnInit(): void {
    this.getHeroes(); //Angular calls ngOnInit() by itself, after the constructor
  }

  getHeroes(): void {
    this.heroService.getHeroes()
      .subscribe(heroes => this.heroes = heroes); //Retrieves heroes from the Service asynchronously by waiting for the Observable to emit the required array data
  }

  onSelect(hero: Hero): void {
    this.selectedHero = hero;
  }
}
