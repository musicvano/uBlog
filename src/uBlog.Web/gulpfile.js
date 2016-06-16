/// <binding Clean='clean' />
"use strict";

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify");

var webroot = "./wwwroot/";

var paths = {
    js: webroot + "js/**/*.js",
    minJs: webroot + "js/**/*.min.js",
    css: webroot + "css/**/*.css",
    minCss: webroot + "css/**/*.min.css",
    concatJsDest: webroot + "js/site.min.js",
    concatCssDest: webroot + "css/site.min.css"
};

gulp.task("clean:js", function (cb) {
    rimraf(paths.concatJsDest, cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.concatCssDest, cb);
});

gulp.task("clean", ["clean:js", "clean:css"]);

gulp.task("min:js", function () {
    return gulp.src([paths.js, "!" + paths.minJs], { base: "." })
        .pipe(concat(paths.concatJsDest))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

gulp.task("min:css", function () {
    return gulp.src([paths.css, "!" + paths.minCss])
        .pipe(concat(paths.concatCssDest))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

gulp.task("min", ["min:js", "min:css"]);

/* Past

// Including dependencies
var gulp = require('gulp'),
    sass = require('gulp-sass'),
    concat = require("gulp-concat"),
    cssmin = require('gulp-cssmin'),
    rename = require('gulp-rename'),
    livereload = require('gulp-livereload');

// Builds all style files
gulp.task('styles', function () {
    // Compiles all *.scss files into *.css
    gulp.src('wwwroot/scss/skeleton.scss')
        .pipe(sass().on('error', sass.logError))
        .pipe(gulp.dest('wwwroot/css'));            

    // Concatenates all *.css files and minfies it into *.min.css
    gulp.src(['wwwroot/css/*.css', "!wwwroot/css/*.min.css"])
        .pipe(concat("wwwroot/css/site.min.css"))
		.pipe(cssmin({ keepSpecialComments: 0 }))
		.pipe(gulp.dest('.', { overwrite: true }))
        .pipe(livereload());
});

// Builds all script files
gulp.task('scripts', function () {

});

// Builds the entire project
gulp.task('build', ['styles', 'scripts'], function () { });

// Watches for the changes in styles and scripts
gulp.task('watch', function () {
    var server = livereload();
    livereload.listen();
   gulp.watch(['wwwroot/scss/**/*.scss'], ['styles']);
// gulp.watch('wwwroot/js/**/*.js', ['scripts']);
});

*/