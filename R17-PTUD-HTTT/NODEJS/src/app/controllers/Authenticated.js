
class Authenticated {
	checkAuthenticated(req, res, next) {
		if (req.isAuthenticated()) {
			return next()
		}
		res.redirect('/login')
	}
	checkNotAuthenticatedShipper(req, res, next) {
		if (req.isAuthenticated()) {
			if (req.user.shipper.userId != 0) {
				return res.redirect('/shipper')
			}
		}
		next()
	}
	checkNotAuthenticated(req, res, next) {
		if (req.isAuthenticated()) {
			return res.redirect('/')
		}
		next()
	}
}
module.exports = new Authenticated()