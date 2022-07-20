import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-hero-search',
  templateUrl: './hero-search.component.html',
  styleUrls: ['./hero-search.component.css']
})
export class HeroSearchComponent {

  public heroes: Hero[];
  public hero: Hero = <Hero>{};

  public searchText: string = '';

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit() {
  }

  public searchHeroes() {
    this.http.get<Hero[]>(this.baseUrl + 'api/heroes1' + '?searchString=' + this.searchText).subscribe(result => {
      this.heroes = result;
    }, error => console.error(error)); 
  }

}

interface Hero {
  id: string;
  firstName: string;
  lastName: string;

}
