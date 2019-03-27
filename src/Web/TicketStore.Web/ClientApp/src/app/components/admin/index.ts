import { EventCreateComponent } from './event/event-create/event-create.component';
import { EventEditComponent } from './event/event-edit/event-edit.component';
import { CategoryCreateComponent } from './category/category-create/category-create.component';
import { CategoryEditComponent } from './category/category-edit/category-edit.component';
import { AdminAllEventComponent } from './event/admin-event.component';


export * from './event/event-create/event-create.component';
export * from './event/event-edit/event-edit.component';
export * from './category/category-create/category-create.component';
export * from './category/category-edit/category-edit.component';
export * from './event/admin-event.component';

export const ADMIN_COMPONTNTS = [
    EventCreateComponent,
    EventEditComponent,
    CategoryCreateComponent,
    CategoryEditComponent,
    AdminAllEventComponent
]