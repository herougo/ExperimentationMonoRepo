function promiseFnAllSequential(promiseFnArr) {
    return new Promise((resolve, reject) => {
        let p = Promise.resolve()
        for (const [i, promiseFn] of promiseFnArr.entries()) {
            p = p.then(promiseFn);
        }
        p.then(() => resolve()).catch(err => {
            reject(err);
        });
    });
}

module.exports = {
    promiseFnAllSequential
}