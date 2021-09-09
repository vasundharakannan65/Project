import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { DisplayblogComponent } from './displayblog/displayblog.component';
import { RouterModule, Routes } from '@angular/router';
import { CommentsComponent } from './comments/comments.component';
import { AddblogComponent } from './addblog/addblog.component';
import { EditblogComponent } from './editblog/editblog.component';
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './home/home.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

const appRouting : Routes = [
  { path:'',component:HomeComponent },
  { path:'blog/:id',component:DisplayblogComponent },
  { path: 'create', component:AddblogComponent },
  {path:'edit/:id',component:EditblogComponent}
]

@NgModule({
  declarations: [
    AppComponent,
    DisplayblogComponent,
    CommentsComponent,
    AddblogComponent,
    EditblogComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRouting),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
