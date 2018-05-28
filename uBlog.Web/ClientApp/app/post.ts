import { Tag } from './tag';

export class Post {
    id: number;
    title: string;
    slug: string;
    content: string;
    dateCreated: Date;
    draft: boolean;
    tags: Tag[];
}