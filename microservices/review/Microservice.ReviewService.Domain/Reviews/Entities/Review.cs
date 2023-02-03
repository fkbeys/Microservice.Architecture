﻿using Microservice.Database;

namespace Microservice.ReviewService.Reviews;

public class Review : Entity<Guid>, IAggregateRoot
{
    public const int MaxTextLength = 500;

    public Guid UserId { get; protected set; }

    public Guid MovieId { get; protected set; }

    public string Text { get; protected set; } = string.Empty;

    public RatingEnum Rating { get; protected set; }

    protected Review()
    {

    }

    public Review
    (
        Guid id,
        Guid userId,
        Guid movieId,
        string text,
        RatingEnum rating
    ) : base(id)
    {
        ArgumentNullException.ThrowIfNull(text, nameof(text));

        UserId = userId;
        MovieId = movieId;
        Text = text;
        Rating = rating;
    }

    public void Update(string text, RatingEnum rating)
    {
        ArgumentNullException.ThrowIfNull(text, nameof(text));

        Text = text;
        Rating = rating;
    }
}