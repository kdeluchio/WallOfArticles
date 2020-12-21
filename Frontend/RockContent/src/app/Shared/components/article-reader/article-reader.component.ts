import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { IArticle } from '../../interfaces/iarticle';
import { ArticleService } from '../../services/article.service';

@Component({
  selector: 'app-article-reader',
  templateUrl: './article-reader.component.html',
  styleUrls: ['./article-reader.component.css']
})
export class ArticleReaderComponent implements OnInit {
  
  @Input() article: IArticle
  @Output() deleted : EventEmitter<void> = new EventEmitter();

  constructor(private service : ArticleService) { }

  ngOnInit(): void {
  }

  liked(): void{
    this.service.Liked(this.article.id).subscribe(x =>{
        this.article.likes = Number(x);
    });
  }

  delete(){
    this.service.Delete(this.article.id).subscribe(x =>{
        this.deleted.emit();
    }); 
  }
}
