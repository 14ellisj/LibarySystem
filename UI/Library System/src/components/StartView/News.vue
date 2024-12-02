<template>
  <body>
    <header>
      <div class="container">
        <h1>Library News</h1>
        <p>Your source for the latest updates from the community library</p>
      </div>
    </header>

    <main>
      <section class="news">
        <article class="news-item">
          <h2>New Book Arrivals!</h2>
          <p class="date">November 25, 2024</p>
          <p>
            We are excited to announce the arrival of several new titles in fiction, non-fiction,
            and children's books. Come check out the latest additions to our collection!
          </p>
        </article>

        <article class="news-item">
          <h2>Library Renovation Completed</h2>
          <p class="date">November 18, 2024</p>
          <p>
            The library has finished its much-needed renovation. We've expanded our reading areas,
            added new study rooms, and improved accessibility. Visit us today to explore the
            changes!
          </p>
        </article>

        <article class="news-item">
          <h2>Book Club Starting Next Month</h2>
          <p class="date">November 12, 2024</p>
          <p>
            Join our new monthly book club! Starting December, we will meet every first Saturday of
            the month to discuss a selected book. All are welcome!
          </p>
        </article>

        <article class="news-item">
          <h2>Storytime for Kids Returns</h2>
          <p class="date">November 5, 2024</p>
          <p>
            We are bringing back Storytime for kids every Wednesday afternoon at 2 PM. Bring your
            little ones to enjoy fun and engaging stories with our talented librarians!
          </p>
        </article>

        <article class="news-item">
          <h2>Library Launches Digital Borrowing</h2>
          <p class="date">October 28, 2024</p>
          <p>
            We are now offering digital borrowing for eBooks and audiobooks! Simply log into our
            online catalog to borrow your favorite titles and read or listen on your devices.
          </p>
        </article>
      </section>
    </main>
  </body>
</template>

<style scoped>
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

body {
  font-family: 'Arial', sans-serif;
  line-height: 1.6;
  background-color: var(--background-color);
  color: #333;
}

.container {
  width: 80%;
  margin: 0 auto;
  padding: 20px;
}

header {
  background-color: var(--secondary-color);
  color: white;
  padding: 20px 0;
  text-align: center;
}

header h1 {
  font-size: 3em;
}

header p {
  font-size: 1.2em;
}

.news {
  margin-top: 30px;
  margin-left: 3%;
  margin-right: 3%;
}

.news-item {
  background-color: white;
  padding: 20px;
  margin-bottom: 20px;
  border-radius: 8px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}

.news-item h2 {
  font-size: 2em;
  color: black;
  margin-bottom: 10px;
}

.news-item .date {
  font-size: 0.9em;
  color: #777;
  margin-bottom: 15px;
}

.news-item p {
  font-size: 1em;
  line-height: 1.5;
}
</style>
