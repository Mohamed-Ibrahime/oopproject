using System;
using System.Collections.Generic;
using System.Linq;

// Abstract class for contact components
public abstract class ContactComponent
{
	// Property for component details
	public abstract string ComponentDetails { get; }

	// Method to display component details
	public void ShowComponent(int componentNumber)
	{
		Console.WriteLine($"Component {componentNumber}: {ComponentDetails}");
		Console.WriteLine("=================================");
	}
}

// User class, inherits from ContactComponent
public class User : ContactComponent
{
	// Properties for user details
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string PhoneNumber { get; set; }

	// Implement abstract property for component details
	public override string ComponentDetails => $"{FirstName} {LastName}, Phone Number: {PhoneNumber}";
}

// Phone class, inherits from ContactComponent
public class Phone : ContactComponent
{
	// Property for phone number
	public string PhoneNumber { get; set; }

	// Implement abstract property for component details
	public override string ComponentDetails => $"Phone Number: {PhoneNumber}";
}

// Contact class
public class Contact
{
	// List to store contact components
	private List<ContactComponent> contactComponents = new List<ContactComponent>();

	// Property to get the count of contact components
	public int Count => contactComponents.Count;

	// Method to add a contact component to the list
	public void AddContactComponent(ContactComponent component)
	{
		contactComponents.Add(component);
	}

	// Method to edit a contact component based on its index
	public void EditContactComponentByIndex(int index, ContactComponent updatedComponent)
	{
		if (index >= 0 && index < contactComponents.Count)
		{
			// Update component details
			contactComponents[index] = updatedComponent;

			Console.WriteLine("Component edited successfully!");
			Console.WriteLine("=================================");
		}
		else
		{
			Console.WriteLine("Invalid index. Component not found.");
			Console.WriteLine("=================================");
		}
	}

	// Method to delete a contact component based on its index
	public void DeleteContactComponentByIndex(int index)
	{
		if (index >= 0 && index < contactComponents.Count)
		{
			// Remove the component from the list
			contactComponents.RemoveAt(index);
			Console.WriteLine("Component deleted successfully!");
			Console.WriteLine("=================================");
		}
		else
		{
			Console.WriteLine("Invalid index. Component not found.");
			Console.WriteLine("=================================");
		}
	}

	// Method to display details of all contact components
	public void ShowAllContactComponents()
	{
		Console.WriteLine("All Contact Components:");

		// Loop through each component and display its details
		for (int i = 0; i < contactComponents.Count; i++)
		{
			contactComponents[i].ShowComponent(i + 1);
		}
	}
}

// Demo class containing the main method
class Demo
{
	// Main method
	static void Main()
	{
		// Create a new Contact object
		Contact contact = new Contact();

		int choice;
		// Display a menu until the user chooses to exit
		do
		{
			Console.WriteLine("1. Add Contact Component");
			Console.WriteLine("2. Edit Contact Component");
			Console.WriteLine("3. Delete Contact Component");
			Console.WriteLine("4. Show All Contact Components");
			Console.WriteLine("5. Exit");

			Console.Write("Enter your choice: ");
			if (int.TryParse(Console.ReadLine(), out choice))
			{
				switch (choice)
				{
					case 1:
						// Add Contact Component
						Console.WriteLine("Enter component details:");
						ContactComponent newComponent = GetContactComponentDetailsFromUser();
						contact.AddContactComponent(newComponent);
						Console.WriteLine("Component added successfully!");
						Console.WriteLine("=================================");
						break;

					case 2:
						// Edit Contact Component
						Console.Write("Enter the index to edit the component: ");
						if (int.TryParse(Console.ReadLine(), out int indexToEdit))
						{
							ContactComponent updatedComponent = GetContactComponentDetailsFromUser(); // Get updated details
							contact.EditContactComponentByIndex(indexToEdit - 1, updatedComponent);
						}
						else
						{
							Console.WriteLine("Invalid index. Please enter a valid integer index.");
							Console.WriteLine("=================================");
						}
						break;

					case 3:
						// Delete Contact Component
						Console.Write("Enter the index to delete the component: ");
						if (int.TryParse(Console.ReadLine(), out int indexToDelete))
						{
							contact.DeleteContactComponentByIndex(indexToDelete - 1);
						}
						else
						{
							Console.WriteLine("Invalid index. Please enter a valid integer index.");
							Console.WriteLine("=================================");
						}
						break;

					case 4:
						// Show All Contact Components
						contact.ShowAllContactComponents();
						break;
				}
			}
			else
			{
				Console.WriteLine("Invalid input. Please enter a valid menu option.");
				Console.WriteLine("=================================");
			}

		} while (choice != 5);
	}

	// Helper method to get contact component details from the user
	private static ContactComponent GetContactComponentDetailsFromUser()
	{
		// Assuming the user can choose between adding a User or a Phone
		Console.WriteLine("Choose Component Type:");
		Console.WriteLine("1. User");
		Console.WriteLine("2. Phone");
		Console.Write("Enter your choice: ");

		if (int.TryParse(Console.ReadLine(), out int componentChoice))
		{
			switch (componentChoice)
			{
				case 1:
					return GetUserDetailsFromUser();

				case 2:
					return GetPhoneDetailsFromUser();

				default:
					Console.WriteLine("Invalid choice. Defaulting to User.");
					return GetUserDetailsFromUser();
			}
		}
		else
		{
			Console.WriteLine("Invalid choice. Defaulting to User.");
			return GetUserDetailsFromUser();
		}
	}

	// Helper method to get user details from the user
	private static User GetUserDetailsFromUser()
	{
		User user = new User();

		Console.Write("First Name: ");
		user.FirstName = Console.ReadLine();

		Console.Write("Last Name: ");
		user.LastName = Console.ReadLine();

		Console.Write("Enter Phone Number: ");
		user.PhoneNumber = Console.ReadLine();

		return user;
	}

	// Helper method to get phone details from the user
	private static Phone GetPhoneDetailsFromUser()
	{
		Phone phone = new Phone();

		Console.Write("Enter Phone Number: ");
		phone.PhoneNumber = Console.ReadLine();

		return phone;
	}
}