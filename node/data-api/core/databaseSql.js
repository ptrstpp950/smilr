const mongoose = require('mongoose-sql');

//
// Creates connection to MongoDB
//
class DatabaseConnectionSql {
  // mongoUrl - is a standard MongoDB connection string
  // connectTimeout - Sets initial connection timeout in millisecs
  constructor(dbClient, dbHost, dbUser, dbPassword, dbName='smilrDb' ) {
    console.log(`### Connecting to ${dbClient}: ${dbHost}`);

    //mongoose.pluralize(null);

    // Note, return the *promise* from .connect()
    return mongoose.connect({
      client: dbClient,
      connection: {
        host: dbHost,
        user: dbUser,
        password: dbPassword,
        database: dbName,
        ssl: true

      }
  });
  }
}

module.exports = DatabaseConnectionSql;