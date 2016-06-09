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

    gulp.watch('wwwroot/scss/**/*.scss', ['styles']);
    // gulp.watch('wwwroot/js/**/*.js', ['scripts']);
});