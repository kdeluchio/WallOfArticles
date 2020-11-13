import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { IArticle } from './Shared/interfaces/iarticle';
import { ArticleService } from './Shared/services/article.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit, OnDestroy{

  destroy$: Subject<void> = new Subject<void>();
  title = 'RockContent';
  articles : IArticle[]

  constructor(private service : ArticleService) { }
  
  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete(); 
  }

  ngOnInit(): void {
    this.load();
  }

  load(){
    this.service.GetAll().subscribe(x =>{
      this.articles = x;
    });
  }

}
