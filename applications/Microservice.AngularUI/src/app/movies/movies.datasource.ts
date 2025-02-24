import { CollectionViewer, DataSource } from "@angular/cdk/collections";
import { Observable, BehaviorSubject, of } from "rxjs";
import { catchError, finalize } from "rxjs/operators";
import { MovieDto, MovieListDto, MoviesAPIService } from "../api-services/api-services";

export class MoviesDataSource implements DataSource<MovieDto> {

  private itemsSubject = new BehaviorSubject<MovieDto[]>([]);

  private totalCountSubject = new BehaviorSubject<number>(0);

  private loadingSubject = new BehaviorSubject<boolean>(false);

  public totalCount$ = this.totalCountSubject.asObservable();

  public loading$ = this.loadingSubject.asObservable();

  constructor(private moviesAPIService: MoviesAPIService) {

  }

  load(pageIndex: number, pageSize: number) {
    this.loadingSubject.next(true);

    this.moviesAPIService.getMovieList(pageIndex, pageSize)
      .pipe(
        catchError(() => of([])),
        finalize(() => this.loadingSubject.next(false))
      )
      .subscribe(result => {
        this.itemsSubject.next((result as MovieListDto).items);
        this.totalCountSubject.next((result as MovieListDto).totalCount);
      });
  }

  connect(collectionViewer: CollectionViewer): Observable<MovieDto[]> {
    return this.itemsSubject.asObservable();
  }

  disconnect(collectionViewer: CollectionViewer): void {
    this.itemsSubject.complete();
    this.totalCountSubject.complete();
    this.loadingSubject.complete();
  }
}
