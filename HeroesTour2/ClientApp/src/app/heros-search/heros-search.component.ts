import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-heros-search',
  templateUrl: './heros-search.component.html',
  styleUrls: ['./heros-search.component.css']
})
export class HerosSearchComponent {

  public heroes!: Hero[];
  private searchTerms: string = '';

  constructor() {

  }

  //public search(term: string): void {
  //  this.http.get<Hero[]>(this.baseUrl + 'api/heroes/' + '?firstName='  ).subscribe(result => {
  //    this.heroes = result;
  //  }, error => console.error(error));
  //}


}

interface Hero {
  id: string;
  firstName: string;
  lastName: string;

}
