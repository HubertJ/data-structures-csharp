## data-structures-csharp

A sandbox repository to test and learn a bit about data structures in C#

***

#### Data Structures

##### Lists

###### SinglyLinkedList

A singly linked list is one that is made up of nodes with a copy of the data and only a single link to the next node in the list. It is only possible to traverse the list in a single direction.


###### DoublyLinkedList

A doubly linked list is very similar to a singly linked list, but, as the name suggests, each node contains two links, the extra being to the previous node in the list. With a doubly linked list it is possible to traverse the list in both direction. From an implementation point of view it also makes deleting nodes a little easier as it has a link to both neighbours that need to be paired up. 


###### SelfOrganizedList

Self organized lists try to reduce the average time complexity by organzing the list dynamically as nodes are accessed. This works by moving the more frequently accessed items to the front of the list so that they are retrieved quicker during a traversal. The worst case complexity is still O(n) however. There are a number of different implementations for self organization as described below:

1) MTF - Move To Front

As a node is accessed, it is moved to the front of the list, shifting everything else down one place. This reacts very quickly to changes which can be positive in some scenarios (e.g. an item that was previously not accessed being moved to the front just in time for a large number of accesses) or negative in others (e.g. an item that only gets accessed once being moved to the front and never being used again)

2) Count

As the name suggests, this method keeps a count of how frequently nodes are accesed and organizes the list so that nodes are ordered by count. This doesn't react to changes as much and it can take a long time for a frequently accessed node to make its way to the front of the list but this does have the benefit of not becoming unorganized as easily as MTF.

3) Transpose (not implemented yet)

This works by swapping the accessed node with the one before it in the list. I will update the notes when I actually implement this. 


###### ArrayList

The array list implementation stores the data in a contiguous chunk of memory that is dynamically resized as it is needed. This makes accessing the contents of the list much easier as an index can be used to efficiently find the position in the list instead of requiring a traversal through the list to get to the value. In order to avoid having to constantly regrow the array for each inserted value the array list implements one of many different growth strategies (essentially they are just different multipliers of the current size! nothing special but choosing the correct one can have a big impact)

This implementation provides three diferent methods : 

1) Doubling 

This simply takes the current size of the array, and doubles it. This requires fewer resizess to reach the same size as the other methods but can result in more space being wasted if the array isn't filled. 

2) Java

This, apparently, is how it java implements the array growth. The multiplier used here is 1.5. This will result in much more conservative memory usage early on in the arrays lifetime but would result in more resizes to reach the same size as a doubled array. Interestingly, using this approach the sum of memory deallocated in previous resizes may provide enough space for future resizes allowing memory to be reused. Using the doubling approach this would never be possible. 

3) Golden 

For this we use the golden ratio ((1 + sqrt(5)) / 2) as the multiplier. The reasoning behind this is similar to the java approach and the golden ratio is the greatest multiplier that exhibits this property but this differes from Java as it requires fewer resizes to get to the same size.


###### Stack

The stack data structure in this implementation uses the ArrayList described above. A stack is a data structure that provide a very simple Last-In-First-Out (LIFO) interface. The operations provided by the interface are to push items onto the stack, peek at the top of the stake and to pop items off the top of the stack. 

***

More information about Data Structures:

1. http://www.syncfusion.com/resources/techportal/ebooks/datastructurespart1 

This was the first ebook I read on data structures and linked lists and it's where the outline for the first commit came from. I would highly recommend it for beginners like me

2. http://en.wikipedia.org/wiki/Linked_list 

3. http://cslibrary.stanford.edu/103/

:koala: