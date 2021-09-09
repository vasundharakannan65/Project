import { Component, OnInit } from '@angular/core';
import { BlogService } from "../services/blog.service";

@Component({
  selector: 'app-addblog',
  templateUrl: './addblog.component.html',
  styleUrls: ['./addblog.component.css']
})
export class AddblogComponent implements OnInit {

  data = {
    blogTitle : ' ',
    blogContent : ' '
  };
 
  constructor(private blogservice : BlogService){}
 
  ngOnInit(): void { }
 
  addNewBlog() : void
  {   
    const datas = {
      blogTitle: this.data.blogTitle,
      blogContent: this.data.blogContent
    };
 
    this.blogservice.create(datas)
      .subscribe((data) => {console.warn("New blog added!"),datas})
  }


}
