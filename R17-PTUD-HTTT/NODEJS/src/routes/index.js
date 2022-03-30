const siteRouter = require('./sites');
const siteBuyer = require('./buyer')
const siteShiper =require('./shipper')
const Authenticated = require('../app/controllers/Authenticated')
function route(app) {
    app.use('/' ,siteBuyer);
    app.use('/', siteRouter);
    app.use('/', siteShiper);
}

module.exports = route;