import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface CustomerModel {
  id: Number;
  name: string;
  address: string;
  city: string;
  postalCode: string;
  country: string;
  phone: string;
  email: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public customers: CustomerModel[] = [];
  public id: Number | null = null;
  public name = "test";
  public address: string = "";
  public city: string = "";
  public postalCode: string = "";
  public country: string = "";
  public phone: string = "";
  public email: string = "";

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getCustomers();
  }

  getCustomers() {
    this.http.get<CustomerModel[]>('/api/customer').subscribe(
      (result) => {
        this.customers = result;
        console.log("customers: ", this.customers);
      },
      (error) => {
        console.error("FUCK!!!", error);
      }
    );
  }

  public createCustomer() {
    this.http.post('/api/customer', {
      Name: this.name,
      Address: this.address,
      City: this.city,
      Country: this.country,
      PostalCode: this.postalCode,
      Phone: this.phone,
      Email: this.email && this.email.length > 0 ? this.email : null
    }).subscribe(
      (result) => {
        this.customers.push({
          id: result as Number,
          name: this.name,
          address: this.address,
          city: this.city,
          country: this.country,
          postalCode: this.postalCode,
          phone: this.phone,
          email: this.email
        })
        this.clearCustomer()
      },
      (error) => console.error("Post Error: ", error)
    )
  }

  public editCustomer(id: Number) {
    var customer = this.customers.filter(c => c.id === id)[0] ?? null;
    if (!customer)
      return;
    this.id = id;
    this.name = customer.name;
    this.address = customer.address;
    this.city = customer.city;
    this.postalCode = customer.postalCode;
    this.country = customer.country;
    this.phone = customer.phone;
    this.email = customer.email;
  }

  public clearCustomer() {
    this.id = null;
    this.name = "";
    this.address = "";
    this.city = "";
    this.postalCode = "";
    this.country = "";
    this.phone = "";
    this.email = "";
  }

  public updateCustomer(id: Number) {
    // Proxy is not allowing put method, I'm not sure why :'(
    this.http.put(`https://localhost:7102/api/customer/${id}`, {
      Name: this.name,
      Address: this.address,
      City: this.city,
      Country: this.country,
      PostalCode: this.postalCode,
      Phone: this.phone,
      Email: this.email && this.email.length > 0 ? this.email : null 
    }).subscribe(
      (result) => {
        this.customers = this.customers.filter(customer => customer.id !== id);
        this.customers.push({
          id: id,
          name: this.name,
          address: this.address,
          city: this.city,
          country: this.country,
          postalCode: this.postalCode,
          phone: this.phone,
          email: this.email
        })
        this.clearCustomer()
      },
      (error) => console.error("Put Error: ", error)
    )
  }

  public deleteCustomer(id: number) {
    // Proxy is not allowing delete method, I'm not sure why :'(
    this.http.delete(`https://localhost:7102/api/customer/${id}`).subscribe(
      (result) => {
        this.customers = this.customers.filter(customer => customer.id !== id);
      },
      (error) => console.error("Post Error: ", error)
    )
  }

  title = 'customerapi.client';
}
