import { EventCreateComponent } from './event/event-create/event-create.component';
import { EventEditComponent } from './event/event-edit/event-edit.component';
import { CategoryCreateComponent } from './category/category-create/category-create.component';


export * from './event/event-create/event-create.component';
export * from './event/event-edit/event-edit.component';
export * from './category/category-create/category-create.component'


export const ADMIN_COMPONTNTS = [
    EventCreateComponent,
    EventEditComponent,
    CategoryCreateComponent
]