import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BehaviorSubject, Observable } from 'rxjs';
import { INewArticle } from '../../interfaces/INewArticle';
import { ArticleService } from '../../services/article.service';

@Component({
  selector: 'app-article-creator',
  templateUrl: './article-creator.component.html',
  styleUrls: ['./article-creator.component.css']
})
export class ArticleCreatorComponent implements OnInit {

  newArticle : FormGroup
  startPost : boolean = false;
  @Output() posted : EventEmitter<void> = new EventEmitter();


  constructor(private formBuilder: FormBuilder,
              private service : ArticleService) { }

  ngOnInit(): void {
      this.newArticle = this.formBuilder.group({
        title: ['', Validators.required],
        text:  ['', Validators.required]
    });
  }

  post(): void {

    if (this.newArticle.invalid) {
      this.startPost = true;
      return;
    }

    let article : INewArticle =
    {
      title : this.newArticle.get("title").value,
      text : this.newArticle.get("text").value
    }

    this.service.Create(article).subscribe(x => {

        this.startPost = false;
        this.newArticle.get("title").setValue("");
        this.newArticle.get("text").setValue("");
        this.posted.emit();

    });

  }

}
