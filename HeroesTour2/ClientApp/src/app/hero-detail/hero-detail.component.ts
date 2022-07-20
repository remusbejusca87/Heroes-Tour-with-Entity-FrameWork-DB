import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-hero-detail',
  templateUrl: './hero-detail.component.html',
  styleUrls: ['./hero-detail.component.css']
})
export class HeroDetailComponent {

  public hero: Hero = <Hero>{};

  public heroes: Hero[];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private route: ActivatedRoute, private location: Location) {
    this.getHero();
  }

  private getHero(): void{
    const id = this.route.snapshot.paramMap.get('id');

    this.http.get<Hero>("http://localhost:5000/" + 'api/heroes1/' + id).subscribe(result => {
      this.hero = result;
    }, error => console.error(error));
  }

  public save(id: string, hero: Hero): void {

    this.http.put<Hero>(this.baseUrl + 'api/heroes1/' + id, hero).subscribe(result => {
      this.location.back();
    }, error => console.error(error));
  }

  public goBack(): void {
    this.location.back();
  }

}


interface Hero {
  id: string;
  firstName: string;
  lastName: string;

}
