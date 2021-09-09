import { Component, OnInit } from '@angular/core';
import { BlogService } from '../services/blog.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  blogs: any = [];

  constructor(private blogservice : BlogService) { }

  ngOnInit(): void {
    this.getAllBlogs();
  }

  // Getting list of blogs
  getAllBlogs(): void {
    this.blogservice.list().subscribe((blogs: any) => {this.blogs = blogs;},(error: any) => {console.log(error);});
  }

}
