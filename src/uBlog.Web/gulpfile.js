/// <binding Clean='clean' />
"use strict";

// Including dependencies
const gulp = require("gulp"),
    del = require("del"),
    //concat = require("gulp-concat"),
    sass = require("gulp-sass"),
    cssmin = require("gulp-clean-css"),
    rename = require("gulp-rename"),
    uglify = require("gulp-uglify");
    //livereload = require("gulp-livereload"),

// Configurations
var webroot = "./wwwroot/";
var noderoot = "./node_modules/";
var paths = {
    app: webroot + "app/",
    libs: webroot + "libs/",
    css: webroot + "css/",
    js: webroot + "js/"
};

////// Removes app folder
////gulp.task("clean:app", function (cb) {
////    return del(paths.app, cb);
////});

//// Removes js folder
//gulp.task("clean:js", function (cb) {
//    return del(paths.js, cb);
//});

//// Removes css folder
//gulp.task("clean:css", function (cb) {
//    return del(paths.css, cb);
//});

////// Removes libs folder
////gulp.task("clean:libs", function (cb) {
////    return del(paths.libs, cb);
////});

gulp.task("clean", [/*"clean:app", "clean:js", "clean:css"*/]);

// Installs libraries from node_modules
//gulp.task("setup", function () {
//    gulp.src(noderoot + "font-awesome/fonts/**/*").pipe(gulp.dest(paths.libs + "font-awesome/fonts"));
//    gulp.src(noderoot + "font-awesome/css/**/*").pipe(gulp.dest(paths.libs + "font-awesome/css"));
//    gulp.src(noderoot + "@angular/**/*.*").pipe(gulp.dest(paths.libs + "@angular"));
//    gulp.src(noderoot + "angular2-in-memory-web-api/**/*.js").pipe(gulp.dest(paths.libs + "angular2-in-memory-web-api"));
//    gulp.src(noderoot + "rxjs/**/*.*").pipe(gulp.dest(paths.libs + "rxjs"));
//    gulp.src(noderoot + "core-js/client/shim.min.js").pipe(gulp.dest(paths.libs + "core-js/client"));
//    gulp.src(noderoot + "zone.js/dist/zone.js").pipe(gulp.dest(paths.libs + "zone.js"));
//    gulp.src(noderoot + "reflect-metadata/Reflect.js").pipe(gulp.dest(paths.libs + "reflect-metadata"));
//    gulp.src(noderoot + "systemjs/dist/system.src.js").pipe(gulp.dest(paths.libs + "systemjs"));
//});

// Compiles all *.scss files into *.css
gulp.task("compile:css", function () {
    return gulp.src(webroot + "src/scss/skeleton.scss")
        .pipe(sass().on("error", sass.logError))
        .pipe(gulp.dest(paths.css));
        //.pipe(livereload());
});

gulp.task("compile", ["compile:css"]);

// Minifies all *.css files in CSS folder
gulp.task("min:css", function () {
    return gulp.src([paths.css + "*.css", "!" + paths.css + "*.min.css"])
         .pipe(cssmin({ keepSpecialComments: 0 }))
         .pipe(rename({ suffix: '.min' }))
         .pipe(gulp.dest(paths.css));
});

// Minifies all *.js files in JS folder
gulp.task("min:js", function () {
    return gulp.src([paths.js + "*.js", "!" + paths.js + "*.min.js"])
        .pipe(uglify())
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest(paths.js));
});

gulp.task("min", ["min:css", "min:js"]);

// Builds the entire project
gulp.task("build", ["clean", "compile", "min"]);

//// Lint all custom TypeScript files
//gulp.task("tslint", function () {
//    return gulp.src(webroot + "src/**/*.ts")
//        .pipe(tslint())
//        .pipe(tslint.report("prose"));
//});

//// Compile TypeScript sources and create sourcemaps in build directory
//gulp.task("compileTS", ["tslint"], function () {
//    let tsResult = gulp.src(webroot + "src/**/*.ts")
//        .pipe(sourcemaps.init())
//        .pipe(tsc(tsProject));
//    return tsResult.js
//        .pipe(sourcemaps.write("."))
//        .pipe(gulp.dest(webroot));
//});

//// Copy all resources that are not TypeScript files into build directory
//gulp.task("resources", function () {
//    return gulp.src([webroot + "src/app/**/*", "!" + webroot + "src/app/**/*.ts"])
//        .pipe(gulp.dest(paths.app));
//});

//// Build the project
//gulp.task("buildTS", ["compileTS", "resources"], function () {
//    console.log("Building the project ...");
//});

// Watches for the changes in styles and scripts
gulp.task("watch", function () {
    //var server = livereload();
    //livereload.listen();
    gulp.watch(webroot + "src/scss/**/*.scss", ["compile:css"]);
});

// Watch for changes in TypeScript, HTML and CSS files
//gulp.task("watchTS", function () {
//    gulp.watch([webroot + "src/**/*.ts"], ["compile"]).on("change", function (e) {
//        console.log("TypeScript file " + e.path + " has been changed. Compiling.");
//    });
//    gulp.watch([webroot + "src/**/*.html", webroot + "src/**/*.css"], ["resources"]).on("change", function (e) {
//        console.log("Resource file " + e.path + " has been changed. Updating.");
//    });
//});
