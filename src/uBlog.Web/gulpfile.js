/// <binding Clean='clean' />
"use strict";

// Including dependencies
var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    sass = require("gulp-sass"),
    cssmin = require("gulp-clean-css"),
    uglify = require("gulp-uglify"),
    livereload = require("gulp-livereload");

// Configurations
var webroot = "./wwwroot/";
var paths = {
    js: webroot + "js/**/*.js",
    minJs: webroot + "js/**/*.min.js",
    scss: webroot + "scss/**/*.scss",
    css: webroot + "css/**/*.css",
    minCss: webroot + "css/**/*.min.css",
    concatJsDest: webroot + "js/site.min.js",
    concatCssDest: webroot + "css/site.min.css"
};

// Removes site.min.js
gulp.task("clean:js", function (cb) {
    rimraf(paths.concatJsDest, cb);
});

// Removes site.min.css
gulp.task("clean:css", function (cb) {
    rimraf(paths.concatCssDest, cb);
});

gulp.task("clean", ["clean:js", "clean:css"]);

// Compiles all *.scss files into *.css
gulp.task("compile:css", function () {
    return gulp.src(webroot + "scss/skeleton.scss")
        .pipe(sass().on("error", sass.logError))
        .pipe(gulp.dest(webroot + "css"))
        .pipe(livereload());
});

gulp.task("compile", ["compile:css"]);

// Concatenates all *.js files and minifies it into site.min.js
gulp.task("min:js", function () {
    return gulp.src([paths.js, "!" + paths.minJs], { base: "." })
        .pipe(concat(paths.concatJsDest))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

// Concatenates all *.css files and minifies it into site.min.css
gulp.task("min:css", function () {
    return gulp.src([paths.css, "!" + paths.minCss])
        .pipe(concat(paths.concatCssDest))
        .pipe(cssmin({ keepSpecialComments : 0}))
        .pipe(gulp.dest("."));
});

gulp.task("min", ["min:js", "min:css"]);

// Builds the entire project
gulp.task("build", ["clean", "compile", "min"]);

// Watches for the changes in styles and scripts
gulp.task("watch", function () {
    var server = livereload();
    livereload.listen();
    gulp.watch(paths.scss, ["clean:css", "compile:css"]);
});