import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-heroes',
  templateUrl: './heroes.component.html',
  styleUrls: ['./heroes.component.css']
})
export class HeroesComponent {

  public heroes: Hero[];
  public hero: Hero = <Hero>{};


  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.getHeroes();
  }

  private getHeroes() {
    this.http.get<Hero[]>(this.baseUrl + 'api/heroes').subscribe(result => {
      this.heroes = result;
    }, error => console.error(error));
  }

  public addHero(hero: Hero) {
    hero.firstName = hero.firstName.trim();
    hero.lastName = hero.lastName.trim();

    if (!this.hero.firstName || !this.hero.lastName) { return; }

    this.http.post<Hero[]>(this.baseUrl + 'api/heroes', this.hero).subscribe(result => {
      this.hero = <Hero>{};
      this.getHeroes();
    }, error => console.error(error));
  }

  public deleteHero(hero: Hero) {
    this.http.delete<Hero>(this.baseUrl + 'api/heroes' + '?id=' + hero.id).subscribe(result => {
      this.getHeroes();
    }, error => console.error(error));
  }


}


interface Hero {
  id: string;
  firstName: string;
  lastName: string;

}
