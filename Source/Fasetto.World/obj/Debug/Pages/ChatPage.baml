   M S B A M L   `   `   `  ����H  DFasetto.World, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Fasetto.WorldFasetto.World  5      M IFasetto.World.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS<clr-namespace:Fasetto.World.Core;assembly=Fasetto.World.CoreFasetto.World.Core 5          Fasetto.World.ChatPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Fasetto.World     5      Mcore<clr-namespace:Fasetto.World.Core;assembly=Fasetto.World.Core     5      -   5           Fasetto.World.BasePage`1   Name$
  Page��5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� 
������ $��2��5       K� ZIndex$ 1��5      y�5      �� *AnyPopupVisible+ �� 	Converter 0   *Fasetto.World.BooleanToVisibilityConverter   �� ConverterParameter$
 true�� J� InputBindings 5      d� 5       d� MouseAction$ 	LeftClicke�6    �� Command 67   �� *PopupClickAwayCommand+5      � 5!   
   $��50��6    � ColumnDefinitions 5"      �� 5#      $��* �6#   �� 5$      $
��Auto �6#   .+�5(      �� $��2��6      ForegroundLightBrush#��[  5*        FontSizeXLarge#��[ 5+        LatoRegular#��[ 5,      $��Center=�5-      $��Center=�5.      ��5)      �� *DisplayTitle+5.      �� 52      	 �� Orientation$	 
Horizontal=�6   $��1��62   .+�54      ��   IconGrowButton#��[ 6     FontAwesomeSearchIcon#��[ 55      ��56      �� *OpenSearchCommand+�� 59      #��[ 6    # FontAwesomeEllipsisVerticalIcon#��[ 5:      5<      � 5?      $��2��6   $��Right=�5@      ��5A      �� *ActualWidth+
 �� RelativeSource
 ��  �� Mode$ FindAncestor=� �� AncestorType$
 GridL��   �Fasetto.World.BaseAttachedProperty`2[[Fasetto.World.AnimateSlideInFromRightProperty, Fasetto.World, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value 5B      �� *SearchIsOpen+ 5D      �� 5E      $
��Auto �6'   �� 5F      $��* �6'   .+�5J      �� #��[ 6     FontAwesomeCloseIcon#��[ 5K        WordOrangeBrush#��[ 5L      ��5M      �� *CloseSearchCommand+�� 5P      $��1��6   
 � Tag$ Search text...��5Q      $��0 5 5 5q�5T        FontSizeRegular#��[ 5U      �   �Fasetto.World.BaseAttachedProperty`2[[Fasetto.World.IsFocusedProperty, Fasetto.World, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value 5R      �� *SearchIsOpen+��5S      �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�.��5V       5W      �� 5Y      
 �� Key$	 Esc��6L    6%   �� *ClearSearchCommand+6L   �� 5[      $ Return��6G    6%   �� *SearchCommand+6G   .��5\   -   5^      5a      5b      *   $Fasetto.World.ChatMessageListControl  5e   
   -   5          Name$ ChatMessageList��5e   '   $��1��6@   �� 5h   
   $��1��6   $ 2��5i      $��Bottom=�5k      $
��Left=�5l      �   �Fasetto.World.BaseAttachedProperty`2[[Fasetto.World.AnimateSlideInFromBottomProperty, Fasetto.World, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value 5j      �� *AttachmentMenuVisible+._�5n      !   Fasetto.World.BubbleContent   � DataContext 6"   �� *AttachmentMenu+5p      � 5s   
   $��2��6   $ 3��5t      $��50��5u      $	��114��5v      #��[  5w       5x      �� 5y      $
��Auto �6#   �� 5z      $��* �6#   �� 5{      $
��Auto �6#   .+�5      �� #��[ 6   $��Bottom=�5�       	 FontAwesomePaperclipIcon#��[	 5�       
 ForegroundDarkBrush#��[
 5�      ��5�      �� *	MinHeight+
 �� $
 GridL���5�      �� *AttachmentButtonCommand+5�      �� 5�      -   5         ��Name$ MessageText��5�      $��1��5�      $
��0 10q�5�       . $ Write a message...��5�      #��[ 5�      #��[ 5�      $��Center=�5�      $��0q�5�       �� AcceptsReturn .  �� 
AcceptsTab .  �� TextWrapping$
 Wrap=�5�      " �� VerticalScrollBarVisibility$
 Auto=�5�      ��5�      �� *PendingMessageText+$ PropertyChanged=�5�      �� 5�      $��2��6   $	 
Horizontal=�5�      $��0 0 10 0q�5�      $��Bottom=�5�      .+�5�      �� #��[ 6     FontAwesomeEmojiIcon#��[ 5�      #��[ 5�      ��5�      �� *	MinHeight+
 �� $
 GridL�5�      �� 5�      $
��Send��6   $��8q�5�       �� 	IsDefault . |�.    WordGreenBrush#��[ 5�      #��[ 5�      #��[ 5�      ��5�      �� *SendCommand+5�      5�      5�      5�      5�      