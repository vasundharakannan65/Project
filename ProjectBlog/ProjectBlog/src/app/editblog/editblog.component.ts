import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BlogService } from '../services/blog.service';

@Component({
  selector: 'app-editblog',
  templateUrl: './editblog.component.html',
  styleUrls: ['./editblog.component.css']
})
export class EditblogComponent implements OnInit {

  id: any;
  blogDetails: any;
  editForm: FormGroup = new FormGroup({});
  dataLoaded: boolean = false;
 
  constructor(private blogservice: BlogService, 
    private route: ActivatedRoute, 
    private builder: FormBuilder) { }
 
  ngOnInit(): void {
    this.dataLoaded = false;
    this.route.params.subscribe((data) => {
      this.id = data.id;
    });
 
    if (this.id !== '') {
      this.blogservice.getItem(this.id).toPromise().then((data) => {
        this.blogDetails = data;
        Object.assign(this.blogDetails, data);
 
        this.editForm = this.builder.group({
          'blogTitle': new FormControl(this.blogDetails.blogTitle),
          'blogContent': new FormControl(this.blogDetails.blogContent)
        })
 
        this.dataLoaded = true;
 
      })
        .catch(err => {
          console.log(err);
        })
    }
  }
 
  editBlog()
  {
    this.blogservice.update(this.id, {...this.editForm.value, id: parseInt(this.id) }).subscribe((data) => 
    console.log("Updated"), this.editForm.value);
  } 

}