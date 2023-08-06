# Movie App API Documentation

Welcome to the documentation for the Movie App API. This API provides endpoints to manage movie data and user preferences.

## Table of Contents

- [Getting Started](#getting-started)
- [Endpoints](#endpoints)
  - [Get All Movies](#get-all-movies)
  - [Add Movie to Favorites](#add-movie-to-favorites)
  - [Set Movie Watch Status](#set-movie-watch-status)
- [Error Handling](#error-handling)

## Getting Started

To start using the Movie App API, you need to obtain an API key by signing up on our platform. This API key is required for authentication and authorization.

## Endpoints

### Get All Movies

- Endpoint: `GET /movies`
- Description: Get a list of all movies.
- Query Parameters:
  - `sort_by`: Sort movies by release date or rating (optional)

Example Request:
GET /movies?sort_by=release_date
Example Response:
```json
[
  {
    "id": 1,
    "title": "Movie Title",
    "releaseDate": "2023-08-15",
    "rating": 4.5
    // Other movie properties...
  },
  // More movies...
]
