// Including dependencies
var gulp = require('gulp');
var sass = require('gulp-sass');
var cssmin = require('gulp-cssmin');
var rename = require('gulp-rename');
var del = require('del');

// Configurations for paths
var paths = {
    root: 'wwwroot/'
};

var config = {
    //Include all *.scss files
    src: ['wwwroot/scss/**/*.scss']
}

// Deletes all *.min.css files
gulp.task('clean', function () {
    return del([paths.root + 'css/*.min.css']);
});

// Compiles all *.scss files into *.css
gulp.task('styles', function () {
    gulp.src(paths.root + 'scss/skeleton.scss')
        .pipe(sass().on('error', sass.logError))
        .pipe(gulp.dest(paths.root + 'css'));
});

// Performs minfication of all *.css files into *.min.css
gulp.task('minify-css', ['clean'], function () {
    gulp.src(paths.root + 'css/*.css')
		.pipe(cssmin({ keepSpecialComments: 0}))
		.pipe(rename({ suffix: '.min' }))
		.pipe(gulp.dest(paths.root + 'css'));
});

// Builds the entire project
gulp.task('build', ['styles', 'minify-css'], function () { });

// Watch for the changes in *.scss files 
gulp.task('watch', function () {
    return gulp.watch(config.src, ['build']);
});