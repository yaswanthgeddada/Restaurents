using System.Runtime.CompilerServices;
using FluentValidation;
using Restaurents.Application.Commands;

namespace Restaurents.Application.DTOs.Validators;

public class CreateRestaurentCommandValidator : AbstractValidator<CreateRestaurentCommand>
{
  private readonly List<string> Categories = ["Restaurant",
  "Café",
  "Bakery",
  "Grocery Store",
  "Supermarket",
  "Clothing Store",
  "Electronics Store",
  "Furniture Store",
  "Pharmacy",
  "Bookstore",
  "Salon",
  "Spa",
  "Gym / Fitness Center",
  "Repair Service",
  "Cleaning Service",
  "Delivery Service",
  "Car Wash",
  "Pet Care",
  "Photography Studio",
  "Event Management",
  "E-commerce",
  "Software Company",
  "Digital Agency",
  "IT Services",
  "Freelancing Platform",
  "Education / E-Learning",
  "Clinic",
  "Dental Hospital",
  "Diagnostic Center",
  "Physiotherapy Center",
  "Veterinary Clinic",
  "Fast Food",
  "Fine Dining",
  "Catering",
  "Food Truck",
  "Juice Bar",
  "Fashion Boutique",
  "Art Gallery",
  "Tattoo Studio",
  "Music School",
  "Dance Academy"];
  public CreateRestaurentCommandValidator()
  {


    RuleFor(dto => dto.Name).Length(3, 100).WithMessage("Length should be min 3 max 100");
    RuleFor(dto => dto.Description).NotEmpty().WithMessage("Description is required");
    RuleFor(dto => dto.ContactEmail).EmailAddress().WithMessage("Provide a valid email id");
    RuleFor(dto => dto.Category).Must(c => Categories.Contains(c)).WithMessage("Category is invalid");

  }
}
