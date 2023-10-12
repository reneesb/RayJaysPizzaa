using RayJaysPizza.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using RayJaysPizza;

var builder = WebApplication.CreateBuilder(args);

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<RayJaysPizzaDbContext>(builder.Configuration["RayJaysPizzaDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});



// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:3000",
                                "http://localhost:5169")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});
var app = builder.Build();
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Create an employee user
app.MapPost("/api/employees", (Employees employees, RayJaysPizzaDbContext db) =>
{
    db.Employees.Add(employees);
    db.SaveChanges();

    return Results.Created($"/employees/{employees.Id}", employees);
});

//Delete an employee user
app.MapDelete("/api/employees/{Id}", (int Id, RayJaysPizzaDbContext db) => 
{
    Employees employees = db.Employees.FirstOrDefault(emp => emp.Id == Id);
    
    if (employees == null)
    {
        return Results.NotFound();
    }

    db.Employees.Remove(employees); db.SaveChanges(); return Results.Ok(employees);
});

//Get all employee users
app.MapGet("/api/employees", (RayJaysPizzaDbContext db) => 
{
    return db.Employees.ToList();
});

//Update an employee user
app.MapPut("/api/employees/{Id}", (int Id, Employees updatedEmployee, RayJaysPizzaDbContext db) =>
{
    Employees employee = db.Employees.FirstOrDefault(emp =>emp.Id == Id);

    if (employee == null)
    {
        return Results.NotFound();
    }

    employee.FirstName = updatedEmployee.FirstName;
    employee.LastName = updatedEmployee.LastName;
    employee.UserName = updatedEmployee.UserName;
    db.SaveChanges();
    return Results.Ok(employee);

});//Authentication
app.MapGet("/checkuser/{uid}", (RayJaysPizzaDbContext db, string uid) => 
{
    var employee = db.Employees.Where(em => em.UID == uid).FirstOrDefault();
    if (uid == null)
    {
        return Results.NotFound();
    }
    else
    {
        return Results.Ok(employee);
    }
});

//Create a customer
app.MapPost("/api/customers", (Customers customer, RayJaysPizzaDbContext db) => 
{ 
    db.Customers.Add(customer);
    db.SaveChanges(); return Results.Ok(customer);
});


//Get customers
app.MapGet("/api/customers", (RayJaysPizzaDbContext db) => 
{
    return db.Customers.ToList();
});

//Update a customer
app.MapPut("/api/customers/{Id}", (int Id, Customers updatedCustomer, RayJaysPizzaDbContext db) =>
{
    Customers customers = db.Customers.FirstOrDefault(customers => customers.Id == Id);

    if (customers == null)
    {
        return Results.NotFound();
    }

    customers.Email = updatedCustomer.Email;
    customers.FirstName = updatedCustomer.FirstName;
    customers.LastName = updatedCustomer.LastName;
    db.SaveChanges();
    return Results.Ok(customers);
});

//Delete a customer
app.MapDelete("/api/customers/{Id}", (int Id, RayJaysPizzaDbContext db) =>
{
    var customer = db.Customers.FirstOrDefault(c => c.Id == Id);
    if (customer == null)
    {
        return Results.NotFound(customer);
    }
    db.Customers.Remove(customer);
    db.SaveChanges(); return Results.Ok();
});

//Create items
app.MapPost("/api/items", (Items item, RayJaysPizzaDbContext db) =>
{
    db.Items.Add(item);
    db.SaveChanges(); return Results.Ok(item);
});

//Delete an item
app.MapDelete("/api/items/{Id}", (int Id, RayJaysPizzaDbContext db) =>
{
    Items items = db.Items.FirstOrDefault(item => item.Id == Id);
    if (items == null)
    {
        return Results.NotFound();
    }
    db.Items.Remove(items);
    db.SaveChanges(); return Results.Ok(items);
});

//Get all items
app.MapGet("/api/items", (RayJaysPizzaDbContext db) =>
{
    return db.Items.ToList();
});

//Update an item
app.MapPut("/api/items/{Id}", (int Id, Items itemsUpdated, RayJaysPizzaDbContext db) =>
{
    Items items = db.Items.FirstOrDefault(i => i.Id == Id);
    if (items == null)
    {
        return Results.NotFound();
    }

    items.ItemPrice = itemsUpdated.ItemPrice;
    items.ItemName = itemsUpdated.ItemName;
    db.SaveChanges();
    return Results.Ok(items);
});

//Create a payment type
app.MapPost("/api/paymenttypes", (PaymentType paymentType, RayJaysPizzaDbContext db) =>
{
    db.PaymentTypes.Add(paymentType);
    db.SaveChanges(); return Results.Ok(paymentType);
});

//Delete a payment type
app.MapDelete("/api/paymenttypes/{Id}", (int Id, RayJaysPizzaDbContext db) =>
{
    PaymentType paymentType = db.PaymentTypes.FirstOrDefault(pt  => pt.Id == Id);
    if(paymentType == null)
    {
        return Results.NotFound();
    }
    db.PaymentTypes.Remove(paymentType); db.SaveChanges(); return Results.Ok();
});

//Get all payment types
app.MapGet("/api/paymenttypes", (RayJaysPizzaDbContext db) => 
{
   return db.PaymentTypes.ToList();
});

//Create a rating
app.MapPost("/api/ratings", (Ratings ratings, RayJaysPizzaDbContext db) =>
{
    db.Ratings.Add(ratings);
    db.SaveChanges(); return Results.Ok();
});

//Create a status
app.MapPost("/api/status", (Status status, RayJaysPizzaDbContext db) =>
{
    db.Status.Add(status);
    db.SaveChanges(); return Results.Ok();
});

app.MapPut("/api/status/{Id}", (int Id, Status updatedStatus, RayJaysPizzaDbContext db) =>
{
    Status status = db.Status.FirstOrDefault(st => st.Id == Id);
    if(status == null)
    {
        return Results.NotFound();
    }

    status.OrderStatus = updatedStatus.OrderStatus;
    db.SaveChanges(); return Results.Ok();

});

//Create an order
app.MapPost("/api/orders", (Orders order, RayJaysPizzaDbContext db) =>
{
    db.Orders.Add(order);
    db.SaveChanges(); return Results.Ok();
});

//Create order items
app.MapPost("/api/orderitems/{Id}", (OrderItems orderItems, RayJaysPizzaDbContext db) =>
{
    db.OrderItems.Add(orderItems);
    db.SaveChanges(); return Results.Ok();
});

//Delete an order
app.MapDelete("/api/orders/{Id}", (int Id, RayJaysPizzaDbContext db) =>
{
    var order = db.Orders.FirstOrDefault(o => o.Id == Id);
    if(order == null)
    {
        return Results.NotFound();
    }
    db.Orders.Remove(order);
    db.SaveChanges(); return Results.Ok();
});

app.Run();

