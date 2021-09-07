import { Component, OnInit } from '@angular/core';
import { BlogService } from "./../blog.service";

@Component({
  selector: 'app-addblog',
  templateUrl: './addblog.component.html',
  styleUrls: ['./addblog.component.css']
})
export class AddblogComponent implements OnInit {

  constructor(private blogservice : BlogService) { }

  blog = {
    BlogTitle : '',
    BlogContent : ''
  }
  ngOnInit(): void {
  }

  addBlog(): void {
    const data = {
      BlogTitle: this.blog.BlogTitle,
      BlogContent: this.blog.BlogContent
    };

    if (!data.BlogTitle) {
      alert('Please add title!');
      return;
    }

    this.blogservice.create(data)
      .subscribe(
        response => {
          console.log(response);
        },
        error => {
          console.log(error);
        });

  }

  //resetting the values
  newBook(): void {
    this.blog = {
      BlogTitle: '',
      BlogContent: ''
    };
  }

}
