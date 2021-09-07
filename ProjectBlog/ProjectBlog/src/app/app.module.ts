import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { DisplaylistofblogsComponent } from './displaylistofblogs/displaylistofblogs.component';
import { DisplayblogComponent } from './displayblog/displayblog.component';
import { RouterModule, Routes } from '@angular/router';
import { DisplayindividualblogComponent } from './displayindividualblog/displayindividualblog.component';
import { CommentsComponent } from './comments/comments.component';
import { AddblogComponent } from './addblog/addblog.component';
import { EditblogComponent } from './editblog/editblog.component';

const appRouting : Routes = [
  {path:'blog',component:DisplayblogComponent,
  children: [
    { path: 'detail/:id', component: DisplayindividualblogComponent },
    { path: 'create', component:AddblogComponent},
    { path: 'edit/:id', component:EditblogComponent}
 ]
}]


@NgModule({
  declarations: [
    AppComponent,
    DisplaylistofblogsComponent,
    DisplayblogComponent,
    DisplayindividualblogComponent,
    CommentsComponent,
    AddblogComponent,
    EditblogComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRouting)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
