#!/bin/sh
./node_modules/.bin/sapper export
git subtree push --prefix __sapper__/export origin gh-pages