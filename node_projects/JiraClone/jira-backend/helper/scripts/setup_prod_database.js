const { Envs } = require('../../lib/config/enums');
const { getDatabase } = require('../../lib/db/database.js');
const { setupDb } = require('../utils/db_utils.js')


const db = getDatabase(Envs.PRODUCTION);
setupDb(db).finally(() => db.close());

