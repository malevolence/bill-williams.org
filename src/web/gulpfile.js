/// <binding Clean='clean' />
"use strict";

var gulp = require("gulp"),
  del = require("del"),
  concat = require("gulp-concat"),
  cssmin = require("gulp-cssmin"),
  uglify = require("gulp-uglify"),
  sass = require("gulp-sass"),
  rename = require("gulp-rename");

var webroot = "./wwwroot/", bowerRoot = "./bower_components/";

var paths = {
  app: './app/**/*.js',
  js: webroot + "js/**/*.js",
  minJs: webroot + "js/**/*.min.js",
  css: webroot + "css/*.css",
  minCss: webroot + "css/**/*.min.css",
  concatJsDest: webroot + "js/site.min.js",
  concatCssDest: webroot + "css/site.min.css",
  bootstrapSass: bowerRoot + "bootstrap/scss/bootstrap.scss",
  bootstrapDest: webroot + "css",
  libsDest: webroot + "lib",
  jsDest: webroot + "js",
  siteSass: './sass/site.scss'
};

var jsLibSrc = [
  bowerRoot + "jquery/dist/*.min.js",
  bowerRoot + "jquery-validation/dist/jquery.validate.min.js",
  bowerRoot + "jquery-validation-unobtrusive/jquery.validate.unobtrusive.min.js",
  bowerRoot + "bootstrap/dist/js/bootstrap.min.js",
  bowerRoot + "tether/dist/js/tether.min.js"
];

var cssLibSrc = [
  bowerRoot + "tether/dist/css/tether.min.css",
  "./content/glyphicons.min.css",
  "./content/glyphicons-social.min.css"
];

gulp.task("clean:js", function () {
  return del(paths.js);
});

gulp.task("clean:css", function () {
  return del(paths.css);
});

gulp.task("clean", ["clean:js", "clean:css"]);

gulp.task("copy:libs", function() {
  return gulp.src(jsLibSrc)
    .pipe(gulp.dest(paths.libsDest));
});

gulp.task("copy:css", function() {
  return gulp.src(cssLibSrc)
    .pipe(gulp.dest(paths.bootstrapDest));
});

gulp.task("copy:sass", function() {
  return gulp.src([ paths.bootstrapSass, paths.siteSass ])
  .pipe(sass())
  .pipe(gulp.dest(paths.bootstrapDest));
});

gulp.task("copy:app", function() {
  return gulp.src(paths.app)
    .pipe(gulp.dest(paths.jsDest));
});

gulp.task("copy", ["copy:libs", "copy:css", "copy:sass", "copy:app"]);

gulp.task("min:sass", function() {
  return gulp.src([ paths.bootstrapSass, paths.siteSass ])
  .pipe(sass({ outputStyle: 'compressed' }))
  .pipe(rename({ suffix: '.min' }))
  .pipe(gulp.dest(paths.bootstrapDest));
});

gulp.task("min:js", function () {
  return gulp.src(paths.app, {
    base: "."
  })
    .pipe(concat(paths.concatJsDest))
    .pipe(uglify())
    .pipe(gulp.dest("."));
});

gulp.task("min", ["min:js", "min:sass"]);

gulp.task("build", ["clean", "copy:libs", "copy:css", "min"]);
