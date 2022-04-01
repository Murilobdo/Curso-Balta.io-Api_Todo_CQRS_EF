using Flunt.Notifications;
using Flunt.Validations;
using System;
using Todo.Domain.Commands.Contracts;

public class UpdateTodoCommand : Notifiable, ICommand
{
	public UpdateTodoCommand()
	{ }

    public UpdateTodoCommand(string title, string user)
    {
        Title = title;
        User = user;
    }
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string User { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract()
                .Requires()
                .AreNotEquals(Guid.Empty, Id, "Id", "Id invalido")
                .HasMinLen(Title, 3, "Title", "Por favor, descreva melhor essa tarefa")
                .HasMinLen(User, 6, "User", "Usuário invalido"));
    }
}
