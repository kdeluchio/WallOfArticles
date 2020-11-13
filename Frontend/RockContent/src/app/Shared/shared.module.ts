import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ArticleCreatorComponent } from './components/article-creator/article-creator.component';
import { ArticleReaderComponent } from './components/article-reader/article-reader.component';

@NgModule({
  declarations: [
    ArticleCreatorComponent,
    ArticleReaderComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  exports: [
    ArticleCreatorComponent,
    ArticleReaderComponent
  ] 
})
export class SharedModule { }
