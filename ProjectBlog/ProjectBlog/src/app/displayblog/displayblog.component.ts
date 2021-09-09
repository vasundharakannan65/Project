import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Blog } from '../model/Blog';
import { BlogService } from '../services/blog.service';

@Component({
  selector: 'app-displayblog',
  templateUrl: './displayblog.component.html',
  styleUrls: ['./displayblog.component.css']
})
export class DisplayblogComponent implements OnInit {

   currentBlog : any;

   id !: number;

  constructor(private blogservice : BlogService,
    private route : ActivatedRoute,
    private router : Router) { 
      this.currentBlog = []
    }

  ngOnInit(): void {
    this.blogservice.getItem(this.route.snapshot.params['id']).subscribe((data: any) => {
      this.currentBlog = data;
    });
  }
}
